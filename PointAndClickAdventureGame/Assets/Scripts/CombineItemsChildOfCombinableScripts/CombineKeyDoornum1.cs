using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineKeyDoornum1 : CombinableObject
{
    public string itemCombine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Combine(string itemToCombineName)
    {
        if (itemCombine == itemToCombineName)
        {

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
           // GetComponent<WomanController>().stopMoving();
           // Managers.Inventory.unEquipedItem();
            //Managers.Dialogue.StartDialogue(8);

           
            //Managers.Dialogue.StartDialogue(8);
           

        }
        else
        {

            Vector3 AimRightHandosition = transform.position;
            foreach (Transform child in transform)
            {
                if (child.tag == "AimToUse")
                {
                    AimRightHandosition = child.transform.position;
                }
            }
            Managers.Player.playerControl.SetTargetRigHandToMoveTo(AimRightHandosition);
            StartCoroutine(waiAndStartAction2());



            

        }
    }

     IEnumerator waiAndStartAction()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<usableObject>().whichUseAction = usableObject.EnumWhichUseAction.use;
        Debug.Log("removed1");
        Managers.Dialogue.StartDialogue(10);
        Managers.Inventory.removeItem(itemCombine);
        Debug.Log("removed2");
        Managers.Player.playerControl.ResetTargetRigValueRightHand();
    }



    IEnumerator waiAndStartAction2()
    {
        yield return new WaitForSeconds(1.0f);
        Managers.Dialogue.StartDialogue(7);
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        Managers.Inventory.unEquipedItem();
        Managers.Player.playerControl.ResetTargetRigValueRightHand();
    }
}