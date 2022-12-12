using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class otherManController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Vector3[] Destinations;
    public int currentDestNum;
    public Animator otherManAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentDestNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
 

    }
    public void stopMoving()
    {

        character.Move(Vector3.zero, false, false);
        agent.SetDestination(transform.position);
        currentDestNum = -1;
        otherManAnimator.SetTrigger("stopMoving");

    }
}
