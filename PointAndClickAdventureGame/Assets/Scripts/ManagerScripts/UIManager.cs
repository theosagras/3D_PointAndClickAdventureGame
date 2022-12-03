using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour, GameManager
{
    Texture2D CursorDefaultTxt;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    
    public ManagerStatus status { get; private set; }
 
    public void Startup()
    {
        Debug.Log("UIManager starting...");
        status = ManagerStatus.Started;

        CursorDefaultTxt = Resources.Load<Texture2D>("Cursor/default");



        Cursor.visible = true;
        setCursorTodefault();


    }
 
    public void setCursorTodefault()
    {
        Cursor.SetCursor(CursorDefaultTxt, hotSpot, cursorMode);
    }

    public void setCursorToItemIconAndUse(Texture2D itemIcon)
    {
        Cursor.SetCursor(itemIcon, hotSpot, cursorMode);
    }




}