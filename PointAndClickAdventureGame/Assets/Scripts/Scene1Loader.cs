using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Loader : MonoBehaviour
{
    public PlayerController _playerControl;
    public Animator _animatorPlayer;
    public GameObject _sceneDialogues;
    public GameObject _sceneChoices;
    private Transform dialogueGizmo;

    public GameObject[] prefabsObjects;


    public Animator demoAnim;
    public GameObject cutSceneDemoAnim;

    public void demotrigerAnim()
    {
        cutSceneDemoAnim.SetActive(true);
    }
    public void demoAnimStop()
    {
        cutSceneDemoAnim.SetActive(false);
    }
    void Start()
    {
        setReferences();
        setPlayerPos();


        foreach (GameObject a in prefabsObjects)
        {
            string itemName = a.GetComponent<InteractableObject>().getName();

            if (!Managers.Inventory.checkIfItemIsInRemoveList(itemName))
             Instantiate(a);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void setReferences()
    {
        Managers.Player.playerControl = _playerControl;
        Managers.Player.animatorPlayer = _animatorPlayer;
        Managers.Dialogue.sceneDialogues = _sceneDialogues;
        Managers.Dialogue.sceneChoices = _sceneChoices;


        //ayta prepei na pane sto scenemanager
        if (GameObject.FindGameObjectWithTag("DialogueUpHeadPosition") != null)
        {
            dialogueGizmo = GameObject.FindGameObjectWithTag("DialogueUpHeadPosition").transform;
            Managers.Dialogue.UpHeadDialogue.GetComponent<PlaceDialogueUpHeadScipt>().UpHeadPosition = dialogueGizmo;
        }
        Managers.Dialogue.UpHeadDialogue.GetComponent<PlaceDialogueUpHeadScipt>().playerUpHeadPosition = dialogueGizmo;
        if (GameObject.FindGameObjectWithTag("WomanUpHeadDialogueGizmo") != null)
            dialogueGizmo = GameObject.FindGameObjectWithTag("WomanUpHeadDialogueGizmo").transform;
        Managers.Dialogue.UpHeadDialogue.GetComponent<PlaceDialogueUpHeadScipt>().womanUpHeadPosition = dialogueGizmo;
        if (GameObject.FindGameObjectWithTag("OtherManUpheadDialogueGizmo") != null)
            dialogueGizmo = GameObject.FindGameObjectWithTag("OtherManUpheadDialogueGizmo").transform;
        Managers.Dialogue.UpHeadDialogue.GetComponent<PlaceDialogueUpHeadScipt>().otherManUpHeadPosition = dialogueGizmo;
        Managers.Dialogue.UpHeadDialogue.GetComponent<PlaceDialogueUpHeadScipt>().UpHeadPosition = dialogueGizmo;




    }
    private void setPlayerPos()
    {
        if (Managers.Scene.previousScene == "LevelScene2")
        {
            Managers.Player.playerControl.transform.position = new Vector3(-4.7f, 0, 0);
            Managers.Player.playerControl.transform.localEulerAngles = new Vector3(-0, 90, 0);

        }

    }
}
