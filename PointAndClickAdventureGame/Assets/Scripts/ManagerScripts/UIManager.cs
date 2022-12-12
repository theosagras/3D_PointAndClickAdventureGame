using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour, GameManager
{
    Texture2D CursorDefaultTxt;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    public GameObject circleClickImg;
    public Canvas canvas;
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
    public void clickShowCircle()
    {
       // RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,Input.mousePosition, canvas.worldCamera,out posOfClick);
        Vector3 posOfClick = canvas.transform.TransformVector(Input.mousePosition);



        Vector3 screenPoint = Input.mousePosition;
        
        circleClickImg.transform.position = screenPoint;
        circleClickImg.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        circleClickImg.SetActive(true);
        StartCoroutine(_clickShowCircle());
    }

    IEnumerator _clickShowCircle()
    {
        
        Vector3 originalScale = circleClickImg.transform.localScale;
        Vector3 destinationScale = new Vector3(0.35f,0.35f,0.35f);

        float currentTime = 0.0f;

        do
        {
            circleClickImg.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / 0.25f);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= 0.25f);

        circleClickImg.SetActive(false);
    }

}