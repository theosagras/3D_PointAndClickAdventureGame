using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour, GameManager
{
    Texture2D CursorDefaultTxt;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    public Animator invAnim;
    public ManagerStatus status { get; private set; }
    public void Startup()
    {
        Debug.Log("UIManager starting...");
        status = ManagerStatus.Started;

        CursorDefaultTxt = Resources.Load<Texture2D>("Cursor/default");



        Cursor.visible = true;
        setCursorTodefault();


    }
    public void InvBtnPressedGoDown()
    {
        invAnim.SetBool("goUp1", false);
        invAnim.SetBool("goDown1", true);
    }
    public void InvBtnPressedGoUp()
    {
        invAnim.SetBool("goUp1", true);
        invAnim.SetBool("goDown1", false);
    }
    public void setCursorTodefault()
    {
        Cursor.SetCursor(CursorDefaultTxt, hotSpot, cursorMode);
    }


}