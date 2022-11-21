using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InteractableObject : MonoBehaviour
{
    [SerializeField] string nameObj;
     [TextArea(3,10)]
    public string[] description;
    public EnumWhichActions whichAction;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    Vector2 pickUpCursorOffset = new Vector2(0, 100);

     Texture2D CursorDefaultTxt;
     Texture2D CursorLookTxtr;
     Texture2D CursorUseTxtr;
     Texture2D CursorExitTxtr;
     Texture2D CursorPickUpTxtr;
     Texture2D CursorSpeakTxtr;
     Texture2D CursorPlayTxtr;


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
            case EnumWhichActions.look:
                lookableObject l_obj = GetComponent<lookableObject>();
                l_obj.act();
                break;

        }
    }


    public enum EnumWhichActions
    {
        look,
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
            case EnumWhichActions.look:
                lookableObject l_obj = GetComponent<lookableObject>();
                l_obj.act();
                return l_obj._getDistanceToActFrom();
        }
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        CursorDefaultTxt = Resources.Load<Texture2D>("Cursor/default");
        CursorLookTxtr = Resources.Load<Texture2D>("Cursor/look");
        CursorUseTxtr = Resources.Load<Texture2D>("Cursor/use");
        CursorPickUpTxtr = Resources.Load<Texture2D>("Cursor/pickUp");
   
    }

    public Vector3 getWaypointIfExistsOtherwiseObjectsPos()
    {   
        //αν το interactableobject έχει child gameobject με tag wayPoint επιστρέφει τη θεση αυτού και ο παίκτης πηγαίνει εκεί.
        foreach (Transform childTransform in transform)
        {
            if (childTransform.CompareTag("wayPoint"))
            {
                return childTransform.position;                
            }
        }
        return transform.position;//αλλιώς πηγαίνει στην position του  interactableobject
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        if (whichAction == EnumWhichActions.look)
        {
            Cursor.SetCursor(CursorLookTxtr, hotSpot, cursorMode);
        }
        else if (whichAction == EnumWhichActions.use)
        {
            Cursor.SetCursor(CursorUseTxtr, hotSpot, cursorMode);
            
        }
        else if (whichAction == EnumWhichActions.pickUp)
        {
            Cursor.SetCursor(CursorPickUpTxtr, pickUpCursorOffset, cursorMode);
        }
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(CursorDefaultTxt, hotSpot, cursorMode);

    }

}

