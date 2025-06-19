using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEditor.Rendering;

public class DialogManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textbox;
    public float typingSpeed = 0.05f;
    [SerializeField] DialogData dialogData;
    private List<string> currentDialog;
    private string currentDialogKey= "prologue";
    private int currentDialogLine=0;
    private bool isTyping = false;
    private bool skip = false;


    void Start()
    {
        currentDialog = dialogData.getDialog(currentDialogKey);
    }


    void Update()
    {
        if (!skip && !isTyping)
        {
            NextSentence();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textbox.text= "";

        foreach (char letter in currentDialog[currentDialogLine])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void NextSentence()
    {
 
        if (currentDialogLine < currentDialog.Count - 1)
        {
            currentDialogLine++;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Koniec dialogu");
        }
    }
}
