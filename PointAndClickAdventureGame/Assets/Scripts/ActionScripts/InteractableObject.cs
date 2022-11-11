using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InteractableObject : MonoBehaviour
{
    [SerializeField] string nameObj;
    [SerializeField] string description;
    public EnumWhichActions whichAction;

    public void act()
    {
        switch (whichAction)
        {
            case EnumWhichActions.pickUp:
                pickableObject p_obj = GetComponent<pickableObject>();
                p_obj.act();
                break;
            case EnumWhichActions.use:
                usableObject u_obj = GetComponent<usableObject>();
                u_obj.act();
                break;
        }
    }


    public enum EnumWhichActions
    {
        use,
        pickUp
    }
    public float getDistanceToActFrom()
    {
        switch (whichAction)
        {
            case EnumWhichActions.pickUp:
                pickableObject p_obj = GetComponent<pickableObject>();
                return p_obj._getDistanceToActFrom();
            case EnumWhichActions.use:
                usableObject u_obj = GetComponent<usableObject>();
                return u_obj._getDistanceToActFrom();
        }
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

