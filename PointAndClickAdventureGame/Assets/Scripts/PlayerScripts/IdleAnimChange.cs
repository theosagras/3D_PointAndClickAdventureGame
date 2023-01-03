using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimChange : MonoBehaviour
{
    public int IdleAnimParam;
    public Animator humanoidAnim;

    void Start()
    {
        
    }
    public void changeIdleAnim()
    {
        IdleAnimParam++;
        if (IdleAnimParam == 1)
        {
            humanoidAnim.ResetTrigger("Idle1");
            humanoidAnim.ResetTrigger("Idle2");
            humanoidAnim.SetTrigger("Idle1");
           
        }
        else if (IdleAnimParam ==5)
        {
            humanoidAnim.ResetTrigger("Idle1");
            humanoidAnim.ResetTrigger("Idle2");
            humanoidAnim.SetTrigger("Idle2");
         
        }
        else if (IdleAnimParam == 10)
        {
            humanoidAnim.ResetTrigger("Idle1");
            humanoidAnim.ResetTrigger("Idle2");
            humanoidAnim.SetTrigger("HappyIdle");
            
        }
    }
    public void ResetIdleAnimParam()
    {
        IdleAnimParam = 0;
    }

}
