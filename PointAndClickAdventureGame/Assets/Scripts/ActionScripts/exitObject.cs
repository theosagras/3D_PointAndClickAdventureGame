using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitObject : MonoBehaviour
{
    public string sceneNameToGo;
    [SerializeField] float distanceFromObjToAct;
    // Start is called before the first frame update
    public void act()
    {
        Managers.Scene.LoadScene(sceneNameToGo);
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
