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
        // animator state IsOpen true will show the menue
        animator.SetBool("IsOpen", true);
        // set name
        nameText.text = dialogue.npcName;
        // clear queue
        sentences.Clear();
        // each conversation points
        foreach(string sentence in dialogue.sentences)
        {
            // conversation to queue
            sentences.Enqueue(sentence);
        }
        // todo start conversation with choice between conversation and action
        // todo implement action & consiquence function
        // start displaying letter by letter the first conversation point
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        // end if no sentance queued
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        // take current sentence out of queue
        string sentence = sentences.Dequeue();
        // stop any coroutines already running
        StopAllCoroutines();
        // print sentence letter by letter
        StartCoroutine(TypeSencence(sentence));
        //dialogueText.text = sentance; // turn back on and cancel coroutine to show normally

    }

    IEnumerator TypeSencence(string sentence)
    {
        // clear any privious text
        dialogueText.text = "";
        // each character in sentence
        foreach (char letter in sentence.ToCharArray())
        {
            // add letter to diologue text box
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        // animator state IsOpen false will hide the menue
        animator.SetBool("IsOpen", false);        
    }
}
