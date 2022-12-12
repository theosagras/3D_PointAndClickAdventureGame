using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBtnPressed : MonoBehaviour
{
    int nextDialogueNum;
    public void setChoicesNextDialogueNum(int nextNum)
    {
        nextDialogueNum = nextNum;
    }
    public void BtnChoicePressed()
    {
        Managers.Dialogue.StartDialogue(nextDialogueNum);
    }
}
