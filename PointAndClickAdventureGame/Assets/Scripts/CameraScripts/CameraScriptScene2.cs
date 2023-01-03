using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptScene2 : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotX;
    private Vector3 _offset;
    void Start()
    {
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
    }
    void LateUpdate()
    {
        /*
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            _rotY += horInput * rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }
        */

        Quaternion rotation = Quaternion.Euler(_rotX,0, 0);
        Vector3 cameraFinalPosWithClamp;
        cameraFinalPosWithClamp = target.position - (rotation * _offset);
        float zValue = cameraFinalPosWithClamp.z;
        float xValue = cameraFinalPosWithClamp.x;
        float xPos = Mathf.Clamp(xValue, -18f, -10f);
        float zPos = Mathf.Clamp(xValue, -12f, 8f);
        

        //cameraFinalPosWithClamp = new Vector3(xPos, cameraFinalPosWithClamp.y, zPos);


        transform.position = cameraFinalPosWithClamp;
        
        transform.LookAt(target);
        /*
        float zRotValue = transform.eulerAngles.x;
        float zRot = Mathf.Clamp(zRotValue, -100, 40);
        float yRotValue = transform.eulerAngles.y;
        if (yRotValue > 180)
            yRotValue = yRotValue-360;
         float yRot = Mathf.Clamp(yRotValue, -20, 20);
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot, zRot);
        */
    }
}
