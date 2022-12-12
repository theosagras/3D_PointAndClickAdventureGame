using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitObject : MonoBehaviour
{
    [SerializeField] float distanceFromObjToAct;
    // Start is called before the first frame update
    public void act()
    {
        Debug.Log("exit");
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
