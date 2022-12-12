using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDialogueUpHeadScipt : MonoBehaviour
{
    public Transform UpHeadPosition;
    public Transform playerUpHeadPosition;
    public Transform womanUpHeadPosition;
    public Transform otherManUpHeadPosition;
    public int distanceFromHead;
    // Start is called before the first frame update
    void Start()
    {
        UpHeadPosition = playerUpHeadPosition;
    }
    public void setWhoIsSpeaking(string name)
    {
        switch (name)
        {
            case ("player"):
                UpHeadPosition = playerUpHeadPosition;
                break;
            case ("woman"):
                UpHeadPosition = womanUpHeadPosition;
                break;
            case ("otherMan"):
                UpHeadPosition = otherManUpHeadPosition;
                break;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //transform.Translate(new Vector3(0, 0.01f, 0));
        
       transform.position = Camera.main.WorldToScreenPoint(UpHeadPosition.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceFromHead, transform.position.z);
        
        if (transform.localPosition.x < -300) transform.localPosition= new Vector3(-300, transform.localPosition.y, 1);
        else if (transform.localPosition.x >300) transform.localPosition = new Vector3(300, transform.localPosition.y, 1);//γα να είναι όλη η πρόταση εντός οθόνης
        else transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1);
        if (transform.localPosition.y < 0) transform.localPosition = new Vector3(transform.localPosition.x, 0, 1);
        else if (transform.localPosition.y > 200) transform.localPosition = new Vector3(transform.localPosition.x,200, 1);
        //  Vector3 uiElementPosition = CanvasCamera.WorldToScreenPoint(CurrentUIElementWorldPosition);
        //  Vector3 coolNewWorldPosition = Camera.main.ScreenToWorldPoint(uiElementPosition);
        
    }
    


}
