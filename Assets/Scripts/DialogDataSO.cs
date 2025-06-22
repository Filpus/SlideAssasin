using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailogData", menuName = "Scriptable Objects/DailogData")]
public class DialogDataSO : ScriptableObject
{
    public Dictionary<string, List<string>> dialogueDict = new Dictionary<string, List<string>>(){
        { "intro", new List<string>()
            {
                "Evil mage’s castle... It used to be my father’s castle.\r\nBefore that traitor poisoned our guards, killed my mother and brothers in their sleep, and finally thrust a dagger through my father’s heart.",
                "I wasn't in my chamber that night — I don't even remember exactly why. Some stupid, childish tantrum made me run into the woods, where I got lost.\r\nI couldn't find my way back — but neither could they find me.",
                "When I finally returned to the city in the morning, all I heard was mourning.\r\nThe coup went unpunished. People were too terrified of the evil forces backing the traitorous mage to protest.Soldiers either pledged loyalty to the new king or were executed.",
                "The traitor ruled freely for almost ten years, but he won't see his 10th coronation anniversary. Tonight is the night I get my revenge. No matter the cost, even if the price is my life.",
                "The traitor is a dead man walking."
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
