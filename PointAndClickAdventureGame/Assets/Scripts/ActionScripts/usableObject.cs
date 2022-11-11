using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableObject : MonoBehaviour
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

        Debug.Log("use");
    
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
