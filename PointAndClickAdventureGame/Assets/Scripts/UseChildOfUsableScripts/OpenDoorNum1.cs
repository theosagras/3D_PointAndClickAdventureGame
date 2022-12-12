using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorNum1 : usableObject
{
    public Animator DoorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public override void specialAct()
    {
        Debug.Log("door open");
        DoorAnim.SetTrigger("Open");
    }
}
