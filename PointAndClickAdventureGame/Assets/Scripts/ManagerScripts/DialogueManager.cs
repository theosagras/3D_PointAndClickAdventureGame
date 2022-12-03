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
    public GameObject uiNextBtn;
    private float timeOpenedDialogueSentence;


    public GameObject DownMainTextGameObject;
    public TextMeshProUGUI DownMainText;

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
        dialogueGameObject.SetActive(true);
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
        uiNextBtn.SetActive(true);
        if (sentences.Count == 1)
            uiNextBtn.SetActive(false);
        else if (sentences.Count == 0)
        {

            EndDialogue();

            return;
        }
        timeOpenedDialogueSentence = 2;//2 δευτερόλεπτα θα παραμεινει ανοιχτή η φράση
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    void EndDialogue()
    {
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        dialogueGameObject.SetActive(false);

    }


    public void StartDescription(string[] description)
    {
        dialogueGameObject.SetActive(true);
        sentences.Clear();
        nameText.text = "Εγώ";
        foreach (string sentence in description)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    void Update()
    {
        if (timeOpenedDialogueSentence > 0)
        {

            timeOpenedDialogueSentence -= Time.deltaTime;
            if (timeOpenedDialogueSentence <= 0)
                DisplayNextSentence();
        }
    }

    public void EnableMainTextCommand(string commandStr)
    {
        DownMainText.text = commandStr;
        DownMainTextGameObject.SetActive(true);
    }
    public void DisableMainTextCommand()
    {
        DownMainText.text = "";
        DownMainTextGameObject.SetActive(false);
    }
    
    public void OpenCommandText()
    {
        string commandStr = "";
    }
}
