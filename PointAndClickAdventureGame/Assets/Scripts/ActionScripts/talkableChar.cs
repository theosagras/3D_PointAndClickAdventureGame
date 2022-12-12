using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkableChar : MonoBehaviour
{
    [SerializeField] float distanceFromObjToAct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void act()
    {
        Debug.Log("talk");
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        GetComponent<DialogueTrigger>().TriggerDialogue();
        if (GetComponent<WomanController>()!=null)
        GetComponent<WomanController>().stopMoving();
        if (GetComponent<otherManController>() != null)
            GetComponent<otherManController>().stopMoving();
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }

}
