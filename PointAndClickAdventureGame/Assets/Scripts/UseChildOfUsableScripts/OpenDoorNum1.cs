using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorNum1 : usableObject
{
    public string PlayerAnim;
    public Animator DoorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public override void specialAct()
    {
        Debug.Log("door open");
        // Managers.Player.setAnimToPlay(PlayerAnim);
        Vector3 AimRightHandosition = transform.position;
        foreach (Transform child in transform)
        {
            if (child.tag == "AimToUse")
            {
                AimRightHandosition = child.transform.position;
            }
        }

        Managers.Player.playerControl.SetTargetRigHandToMoveTo(AimRightHandosition);
        StartCoroutine(waiAndStartAction());
       
    }
    IEnumerator waiAndStartAction()
    {
        yield return new WaitForSeconds(1.5f);
        DoorAnim.SetTrigger("Open");
        Managers.UI_Manager.setCursorTodefault();
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        Managers.Player.playerControl.ResetTargetRigValueHead();
        Managers.Player.playerControl.ResetTargetRigValueRightHand();
    }
}
