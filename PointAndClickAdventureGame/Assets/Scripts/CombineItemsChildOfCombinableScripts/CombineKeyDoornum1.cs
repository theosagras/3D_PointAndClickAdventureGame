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

            Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
           // GetComponent<WomanController>().stopMoving();
           // Managers.Inventory.unEquipedItem();
            //Managers.Dialogue.StartDialogue(8);

            GetComponent<usableObject>().whichUseAction = usableObject.EnumWhichUseAction.use;
            //Managers.Dialogue.StartDialogue(8);
            Debug.Log("removed1");
            Managers.Dialogue.StartDialogue(10);
            Managers.Inventory.removeItem(itemCombine);
            Debug.Log("removed2");
        }
        else
        {
            Managers.Dialogue.StartDialogue(7);
            Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
            Managers.Inventory.unEquipedItem();
        }
    }
}
