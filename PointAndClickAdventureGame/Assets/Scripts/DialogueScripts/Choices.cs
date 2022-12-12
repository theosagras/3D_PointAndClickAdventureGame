using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Choices
{
    public int numID;

    [TextArea(3, 10)]
    public string[] ChoiceSentences=new string[4];
    public int[] nextDialogue = new int[4];
}
