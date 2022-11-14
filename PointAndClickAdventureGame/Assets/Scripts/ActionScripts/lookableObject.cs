using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookableObject : MonoBehaviour
{
    [SerializeField] float distanceFromObjToAct;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public  void act()
    {
        Managers.Player.playerControl.setDirectionToFace(transform.position);
        InteractableObject parentObj = GetComponent<InteractableObject>();
        Managers.Dialogue.StartDescription(parentObj.description);


    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
