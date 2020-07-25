using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Start()
    {

    }
    public void TriggerDialogue()
    {
        // send diologue from trigger to dialogue manager#
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
