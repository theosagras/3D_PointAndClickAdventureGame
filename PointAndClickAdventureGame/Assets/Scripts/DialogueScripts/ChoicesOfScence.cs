using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesOfScence : MonoBehaviour
{
    public Choices[] choice;


    public Choices getChoices(int numChoices)
    {
        return choice[numChoices];
    }
}

