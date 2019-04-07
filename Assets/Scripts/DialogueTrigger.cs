using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        // send diologue from trigger to dialogue manager#
        // todo implement action consiquence into diologue manager
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
