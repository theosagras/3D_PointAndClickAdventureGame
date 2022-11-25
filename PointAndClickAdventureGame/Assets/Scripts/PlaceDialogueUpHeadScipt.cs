using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDialogueUpHeadScipt : MonoBehaviour
{
    public Transform UpHeadPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.Translate(new Vector3(0, 0.01f, 0));
       transform.position = UpHeadPosition.position;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1);
        //  Vector3 uiElementPosition = CanvasCamera.WorldToScreenPoint(CurrentUIElementWorldPosition);
        //  Vector3 coolNewWorldPosition = Camera.main.ScreenToWorldPoint(uiElementPosition);
    }


}
