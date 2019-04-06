using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    // Update is called once per frame
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.npcName;
        //Debug.Log("Start conversation with " + dialogue.npcName);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            //Debug.Log("added to queue " + sentence);
        }
        DisplayNextSentance();
    }


    public void DisplayNextSentance()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentance = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSencence(sentance));
        //dialogueText.text = sentance;
        //Debug.Log(sentance);
    }

    IEnumerator TypeSencence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //Debug.Log("End of conversation.");
    }
}
