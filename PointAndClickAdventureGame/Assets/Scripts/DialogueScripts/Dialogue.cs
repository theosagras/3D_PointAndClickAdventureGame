using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    public int num;
    public string name;
    public int nextnum;
    public int nextChoice;

    [TextArea(3,10)]
    public string[] sentences;

}
