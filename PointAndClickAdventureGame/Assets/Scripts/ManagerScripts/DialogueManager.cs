using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI playerDialogueText;
    public GameObject PlayerDialogueGameObject;

    public GameObject DownChoicesDialogue;
    public TextMeshProUGUI Choice0Btn;
    public TextMeshProUGUI Choice1Btn;
    public TextMeshProUGUI Choice2Btn;
    public TextMeshProUGUI Choice3Btn;


    private Queue<string> sentences;
    public GameObject uiNextBtn;
    private float timeOpenedDialogueSentence;


    public GameObject DownMainTextGameObject;
    public TextMeshProUGUI DownMainText;
    public PlaceDialogueUpHeadScipt PDUH;
    public GameObject sceneDialogues;
    public GameObject sceneChoices;
    public Dialogue dialogue;
    public Choices choices;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void Startup()
    {
        Debug.Log("UIManager starting...");

        status = ManagerStatus.Started;
    }
    public void StartDialogue(int DialogueNumber)
    {
         dialogue = sceneDialogues.GetComponent<DialogueOfScene>().getDialogue(DialogueNumber);



        PDUH.setWhoIsSpeaking(dialogue.name);
        PlayerDialogueGameObject.SetActive(true);

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void StartChoices(int choicesNumber)
    {
        choices = sceneChoices.GetComponent<ChoicesOfScence>().getChoices(choicesNumber);
        PlayerDialogueGameObject.SetActive(false);
        DownChoicesDialogue.SetActive(true);
        Choice0Btn.text = choices.ChoiceSentences[0];
        Choice1Btn.text = choices.ChoiceSentences[1];
        Choice2Btn.text = choices.ChoiceSentences[2];
        Choice3Btn.text = choices.ChoiceSentences[3];
        Choice0Btn.GetComponentInParent<ChoiceBtnPressed>().setChoicesNextDialogueNum(choices.nextDialogue[0]);
        Choice1Btn.GetComponentInParent<ChoiceBtnPressed>().setChoicesNextDialogueNum(choices.nextDialogue[1]);
        Choice2Btn.GetComponentInParent<ChoiceBtnPressed>().setChoicesNextDialogueNum(choices.nextDialogue[2]);
        Choice3Btn.GetComponentInParent<ChoiceBtnPressed>().setChoicesNextDialogueNum(choices.nextDialogue[3]);
        /*
        sentences.Clear();
        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        */
    }


    public void DisplayNextSentence()
    {
        uiNextBtn.SetActive(true);
        if (sentences.Count == 1)
        {
            if (dialogue.nextChoice==0)
            if (dialogue.nextnum == 0)
                uiNextBtn.SetActive(false);
        }
        else if (sentences.Count == 0)
        {
            if (dialogue.nextChoice == 0)
            {
                if (dialogue.nextnum == 0)
                    EndDialogue();
                else
                {
                    StartDialogue(dialogue.nextnum);
                }
            }
            else
            {
                StartChoices(dialogue.nextChoice);
            }
            return;
        }
        timeOpenedDialogueSentence = 2;//2 δευτερόλεπτα θα παραμεινει ανοιχτή η φράση
        string sentence = sentences.Dequeue();
        playerDialogueText.text = sentence;
        

    }
    void EndDialogue()
    {
        uiNextBtn.SetActive(false);
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        PlayerDialogueGameObject.SetActive(false);

    }


    public void StartDescription(string[] description)
    {
        PDUH.setWhoIsSpeaking("player");
        PlayerDialogueGameObject.SetActive(true);
        sentences.Clear();
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
