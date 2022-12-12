using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveglassToWoman : CombinableObject
{
    public string itemCombine;
    public override void Combine(string itemToCombineName)
    {
        Debug.Log("give2");
        if (itemCombine == itemToCombineName)
        {
           
            Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
            GetComponent<WomanController>().stopMoving();
          

            
            Managers.Dialogue.StartDialogue(8);
            Managers.Inventory.unEquipedItem();

        }
        else if (itemToCombineName == "Βάζο")
        {

            Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
            GetComponent<WomanController>().stopMoving();


            Managers.Dialogue.StartDialogue(8);
            Managers.Inventory.unEquipedItem();

        }
        else
        {
            Managers.Dialogue.StartDialogue(7);
            Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
            Managers.Inventory.unEquipedItem();
        }
    }
}
