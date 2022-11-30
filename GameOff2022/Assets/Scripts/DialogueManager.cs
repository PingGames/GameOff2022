using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private Queue<string> _sentences;

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _sentences.Clear();

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        StartCoroutine(TypeSentence(_sentences.Dequeue()));
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            dialogueText.text = "";
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
