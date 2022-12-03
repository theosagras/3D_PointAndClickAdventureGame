using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class WomanController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Vector3[] Destinations;
    public int currentDestNum;

    // Start is called before the first frame update
    void Start()
    {
        currentDestNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)//Κινείται προς προορισμό αν απέχει από αυτόν
        {


            character.Move(agent.desiredVelocity, false, false);

            agent.SetDestination(Destinations[currentDestNum]);
        }
        else
        {
            currentDestNum++;
            if (currentDestNum == Destinations.Length)
                currentDestNum = 0;
            agent.SetDestination(Destinations[currentDestNum]);
        }

    }
}
