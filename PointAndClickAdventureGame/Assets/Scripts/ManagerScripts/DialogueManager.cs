using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueGameObject;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void Startup()
    {
        Debug.Log("UIManager starting...");

        status = ManagerStatus.Started;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue()
    {
        dialogueGameObject.SetActive(false);
    }
}
