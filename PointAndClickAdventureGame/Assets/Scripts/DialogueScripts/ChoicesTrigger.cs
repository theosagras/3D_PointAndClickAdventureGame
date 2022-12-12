using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesTrigger : MonoBehaviour
{
    
    public int choicesNumber;
    public void TriggerDialogue()
    {
        Managers.Dialogue.StartChoices(choicesNumber);
    }
}
