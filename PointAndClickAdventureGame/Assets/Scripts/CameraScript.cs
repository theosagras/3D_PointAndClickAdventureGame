using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    void Start()
    {
        _rotY = transform.eulerAngles.y;
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

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        Vector3 cameraFinalPosWithClamp;
        cameraFinalPosWithClamp = target.position - (rotation * _offset);
        float zValue = cameraFinalPosWithClamp.z;
        float xValue = cameraFinalPosWithClamp.x;
        float zPos = Mathf.Clamp(zValue, -5.87f, 10);
        float xPos = Mathf.Clamp(xValue, -2f, 2f);
        
        cameraFinalPosWithClamp = new Vector3(xPos, cameraFinalPosWithClamp.y, zPos);


        transform.position = cameraFinalPosWithClamp;
        
        transform.LookAt(target);
        float xRotValue = transform.eulerAngles.x;
        float xRot= Mathf.Clamp(xRotValue, -100, 40);
        float yRotValue = transform.eulerAngles.y;
        if (yRotValue > 180)
            yRotValue = yRotValue-360;
         float yRot = Mathf.Clamp(yRotValue, -20, 20);
        
        transform.eulerAngles = new Vector3(xRot, yRot, transform.eulerAngles.z);
    }
}
