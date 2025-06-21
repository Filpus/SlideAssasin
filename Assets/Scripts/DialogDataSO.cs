using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailogData", menuName = "Scriptable Objects/DailogData")]
public class DialogDataSO : ScriptableObject
{
    public Dictionary<string, List<string>> dialogueDict = new Dictionary<string, List<string>>(){
        { "intro", new List<string>()
            {
                "Witaj, bohaterze.",
                "Zanim wyruszysz, musisz coś wiedzieć.",
                "Ta kraina jest pełna niebezpieczeństw."
            }
        } 
    };
    

    public string getNextLine(string dialogueKey, int lineIndex)
    {
        if (dialogueDict != null)
        {
            if (dialogueDict.ContainsKey(dialogueKey) && lineIndex+1 < dialogueDict[dialogueKey].Count)
            {
                return dialogueDict[dialogueKey][lineIndex+1];
            }
        }
        return "";
    }

    public List<string> getDialog(string dialogueKey)
    {
        if (dialogueDict != null && dialogueDict.ContainsKey(dialogueKey))
        {
            return dialogueDict[dialogueKey];
        }
        return new List<string>();
    }
}
