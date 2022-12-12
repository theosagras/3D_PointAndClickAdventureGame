using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWhite : usableObject
{
    public Collider doorCollider;
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
        Managers.Player.setAnimToPlay("PickUp");

        StartCoroutine(OpenDoorNum1());
 
    }
    IEnumerator OpenDoorNum1()
    {
        float secs = GetComponent<usableObject>().SecsBeforeAnim;
        yield return new WaitForSeconds(secs);
        DoorAnim.SetTrigger("Open");
        doorCollider.enabled = false;
    }
}
