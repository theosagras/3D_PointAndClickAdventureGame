using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public void Startup()
    {
        Debug.Log("UIManager starting...");



        status = ManagerStatus.Started;
    }

}