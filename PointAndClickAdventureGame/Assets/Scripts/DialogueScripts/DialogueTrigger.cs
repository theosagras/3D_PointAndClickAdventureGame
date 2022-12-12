using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public int dialogueNumber;
    Dialogue dialogue;
    public void TriggerDialogue()
    {
        Managers.Dialogue.StartDialogue(dialogueNumber);
    }
}
