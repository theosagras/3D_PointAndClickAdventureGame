using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableObject : MonoBehaviour
{
    [SerializeField] float distanceFromObjToAct;
    [TextArea(3, 10)]
    public string[] notActionDialogue;
    public EnumWhichUseAction whichUseAction;
    public enum EnumWhichUseAction
    {
        noActionDialogue,
        use
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public  void act()
    {

        switch (whichUseAction)
        {
            case EnumWhichUseAction.noActionDialogue:
                Managers.Dialogue.StartDescription(notActionDialogue);
                Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
                break;
            case EnumWhichUseAction.use:
                Debug.Log("use");
                break;
        }
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);

    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
