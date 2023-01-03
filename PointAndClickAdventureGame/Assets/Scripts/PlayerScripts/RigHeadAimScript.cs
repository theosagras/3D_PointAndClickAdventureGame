using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigHeadAimScript : MonoBehaviour
{
    public GameObject targetToAimHead;
    private int targetRigValueHead;
    public Rig rigHead;
    void Update()
    {
        rigHead.weight = Mathf.MoveTowards(rigHead.weight, targetRigValueHead, Time.deltaTime);
    }

    public void SetTargetToAimHead(Vector3 target)
    {
        targetToAimHead.transform.position = target;
    }
    public void SettargetRigValueHeadtoOne()
    {
        targetRigValueHead = 1;
    }
    public void ResetTargetRigValueHead()
    {
        targetRigValueHead = 0;
    }
}
