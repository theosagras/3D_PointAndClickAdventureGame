using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    InteractableObject ObjectClickedToAct;
    float DistanceAddedToRemainingDistanceToActFrom;

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (agent.remainingDistance > agent.stoppingDistance + DistanceAddedToRemainingDistanceToActFrom)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
           
            character.Move(Vector3.zero, false, false);
            if (ObjectClickedToAct != null)
            {
                ObjectClickedToAct.act();
                ObjectClickedToAct = null;
                DistanceAddedToRemainingDistanceToActFrom = 0;
                agent.SetDestination(agent.transform.position);
            }

        }
        if (Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {
            ObjectClickedToAct = null;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                if (target != null)
                {

                    ObjectClickedToAct = target;  //θα κάνει ενέργεια όταν φτάσει στο σημείο που βρίσκεται το αντικείμενο
                    DistanceAddedToRemainingDistanceToActFrom = target.getDistanceToActFrom();
                    agent.SetDestination(hit.point);

                }
                else
                {
                    agent.SetDestination(hit.point);//απλά ο παίκτης πηγαίνει στο σημείο
                }
            }
        }

    }
}
