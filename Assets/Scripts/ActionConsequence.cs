using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionConsequence
{
    [TextArea(3, 10)]
    public string action; // string to be attached to button
    public GameObject consequence; // on press button set consiquence to trigger funtion from game object (possibly diologue trigger)
}
