using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickableObject : MonoBehaviour
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
    public void act()
    {
        Debug.Log("PickedUp");
        Managers.Inventory.AddItem("solid");
        Managers.Inventory.DisplayItems();
        Managers.Scene.UpdateNavMesh();
        Destroy(gameObject);
    
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }
}
