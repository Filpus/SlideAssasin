using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEditor.Rendering;
using UnityEditor;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [SerializeField] Transform dialogView;
    [SerializeField] TextMeshProUGUI textbox;
    public float typingSpeed = 0.05f;
    [SerializeField] DialogDataSO dialogData;
    private List<string> currentDialog;
    private string currentDialogKey= "prologue";
    private int currentDialogLine=0;
    
    private bool isTyping = false;
    private bool skip = false;
    private bool endOfDialog = false;


    public void Start()
    {
        GameInput.Instance.OnSkipDialog += DialogOnSkipDialog;
    }
    public void LoadDialog(string dialogKey)
    {
        currentDialogKey = dialogKey;
        currentDialog = dialogData.getDialog(currentDialogKey);
        currentDialogLine = 0;
    }

    public void DialogOnSkipDialog(object sender, EventArgs e)
    {
        if (isTyping && !endOfDialog)
        {
            skip = true;
        }
        else 
        {
            if (!endOfDialog) NextSentence();
            else
            {
                dialogView.gameObject.SetActive(false);
                endOfDialog = false;
            }
        }
        
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textbox.text= "";

        foreach (char letter in currentDialog[currentDialogLine])
        {
            if (skip)
            {
                textbox.text = currentDialog[currentDialogLine];
                skip = false;
                isTyping = false;
                break;
            }
            else
            {
                textbox.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        isTyping = false;
    }

    void NextSentence()
    {
 
        if (currentDialogLine < currentDialog.Count - 1)
        {
            currentDialogLine++;
            isTyping = true;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Koniec dialogu");
            endOfDialog = true;
        }
    }

    public void ShowDialog(string dialogKey)
    {
        dialogView.gameObject.SetActive(true);
        LoadDialog(dialogKey);
        endOfDialog = false;
        currentDialogLine = 0;
        StartCoroutine(TypeLine());
    }
}
