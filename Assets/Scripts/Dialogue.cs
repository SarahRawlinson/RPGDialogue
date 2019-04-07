using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public ActionConsequence[] actionConsequences;
    public string npcName;
    //min text lines, max text lines
    [TextArea(3,10)]
    public string[] sentences;
}
