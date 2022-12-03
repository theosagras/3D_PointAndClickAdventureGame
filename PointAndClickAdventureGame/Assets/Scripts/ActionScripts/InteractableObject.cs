using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InteractableObject : MonoBehaviour
{
    [SerializeField] string nameObj;
    [SerializeField] string nameObjWithArticle;
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
    Texture2D CursorTalkTxtr;
    Texture2D CursorSpeakTxtr;
     Texture2D CursorPlayTxtr;
    public string getName()
    {
        return nameObj;
    }

    public string getNameObjWithArticle()
    {
        return nameObjWithArticle;
    }

    public void act()
    {
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(true);
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
            case EnumWhichActions.talk:
                talkableChar t_obj = GetComponent<talkableChar>();
                t_obj.act();
                break;

        }
    }


    public enum EnumWhichActions
    {
        look,
        use,
        pickUp,
        talk
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
              
                return l_obj._getDistanceToActFrom();
            case EnumWhichActions.talk:
                talkableChar t_obj = GetComponent<talkableChar>();            
                return t_obj._getDistanceToActFrom();
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
        CursorTalkTxtr = Resources.Load<Texture2D>("Cursor/talk");
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
        string commandStr="";
        int equippedItem = Managers.Inventory.equippedInvNum;
        if (equippedItem == -1)
        {
            if (whichAction == EnumWhichActions.look)
            {
                Cursor.SetCursor(CursorLookTxtr, hotSpot, cursorMode);
                commandStr = "κοίταξε ";
            }
            else if (whichAction == EnumWhichActions.use)
            {
                Cursor.SetCursor(CursorUseTxtr, hotSpot, cursorMode);
                commandStr = "χρησιμοποίησε ";

            }
            else if (whichAction == EnumWhichActions.pickUp)
            {
                Cursor.SetCursor(CursorPickUpTxtr, pickUpCursorOffset, cursorMode);
                commandStr = "πάρε ";
            }
            else if (whichAction == EnumWhichActions.talk)
            {
                Cursor.SetCursor(CursorTalkTxtr, pickUpCursorOffset, cursorMode);
                commandStr = "μίλα ";
            }
            commandStr += nameObjWithArticle;

        }
        else
        {
            commandStr = "χρησιμοποίησε ";

            commandStr += Managers.Inventory.invButtons[equippedItem].GetComponent<ItemInvComponent>().nameObjWithArticle;
            string mestr = " με ";
            commandStr += mestr;
            commandStr += nameObjWithArticle;
        }
        Managers.Dialogue.EnableMainTextCommand(commandStr);
        
    }
    private void OnMouseExit()
    {

        int equippedItem = Managers.Inventory.equippedInvNum;
        if (equippedItem == -1)
        {
            Cursor.SetCursor(CursorDefaultTxt, hotSpot, cursorMode);
            Managers.Dialogue.DisableMainTextCommand();
        }
        else
        {
            Managers.Inventory.invButtons[equippedItem].GetComponent<ItemClickInvenoryScript>().ItemClicked();
        }
        
    }

}

