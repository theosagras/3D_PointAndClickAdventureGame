using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableObject : MonoBehaviour
{
    [SerializeField] float distanceFromObjToAct;
    [TextArea(3, 10)]
    public string[] notActionDialogue;
    public float SecsBeforeAnim;
    public EnumWhichUseAction whichUseAction;
    public string notActionPlayerAnim;
    public float secsBeforDialogue;
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
    public void act()
    {
        switch (whichUseAction)
        {
            case EnumWhichUseAction.noActionDialogue:
                StartCoroutine(waiAndStartDialog());
                
                Managers.Player.setAnimToPlay(notActionPlayerAnim);

                break;
            case EnumWhichUseAction.use:
                Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);

                specialAct();
                break;
        }
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
    }
    IEnumerator waiAndStartDialog()
    {
        yield return new WaitForSeconds(secsBeforDialogue);
        Managers.Dialogue.StartDescription(notActionDialogue);

    }
        public virtual void specialAct()
    {

    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
