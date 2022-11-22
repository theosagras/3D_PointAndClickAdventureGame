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

        float zPos = Mathf.Clamp(zValue, -5.87f, 10);
        cameraFinalPosWithClamp = new Vector3(cameraFinalPosWithClamp.x, cameraFinalPosWithClamp.y, zPos);


        transform.position = cameraFinalPosWithClamp;

        transform.LookAt(target);
    }
}
