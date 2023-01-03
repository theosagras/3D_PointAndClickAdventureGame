using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigRightHandMoveToScript : MonoBehaviour
{
    public GameObject targetTomoveHand;
    private int targetRigValueRightHand;
    public Rig rigRightHand;
    void Update()
    {
        rigRightHand.weight = Mathf.MoveTowards(rigRightHand.weight, targetRigValueRightHand, Time.deltaTime*2);
    }

    public void SetTargetRightHandtoMoveTo(Vector3 target)
    {
        SettargetRigValueRightHandtoOne();
        targetTomoveHand.transform.position = target;
    }
    public void SettargetRigValueRightHandtoOne()
    {
        targetRigValueRightHand = 1;
    }
    public void ResetTargetRigValueRightHan()
    {
        targetRigValueRightHand = 0;
    }
}
