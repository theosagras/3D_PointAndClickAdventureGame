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

    InteractableObject ObjectClickedToLookOrExamine;
    float DistanceAddedToRemainingDistanceToActFrom;
    bool isTurningToLookOrExamine;
    Vector3 direcToTurn;


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
            if (isTurningToLookOrExamine)
            {
                Quaternion rot = Quaternion.LookRotation(direcToTurn);//στροφή παίκτη προς στόχο
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, 5 * Time.deltaTime);

                Debug.Log(Mathf.Abs(Quaternion.Dot(transform.rotation, rot)));
                if (Mathf.Abs(Quaternion.Dot(transform.rotation, rot)) > 0.99f)// να ο παίκτης κοιτάει προς στόχο τότε θα κάνει 
                {
                    isTurningToLookOrExamine = false;
                    if (ObjectClickedToLookOrExamine!=null)
                        Managers.Dialogue.StartDescription(ObjectClickedToLookOrExamine.description);
                }
            }


            else if (ObjectClickedToLookOrExamine != null)//Εφτασε στον προορισμό, κάνει act
            {
                ObjectClickedToLookOrExamine.act();
                ObjectClickedToLookOrExamine = null;
                DistanceAddedToRemainingDistanceToActFrom = 0;
                stopMoving();
            }

        }
        //left mouse click
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {
            ObjectClickedToLookOrExamine = null;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                if (target != null)
                {

                    ObjectClickedToLookOrExamine = target;  //θα κάνει ενέργεια όταν φτάσει στο σημείο που βρίσκεται το αντικείμενο
                    DistanceAddedToRemainingDistanceToActFrom = target.getDistanceToActFrom();
                    agent.SetDestination(hit.point);


                }
                else
                {
                    agent.SetDestination(hit.point);//απλά ο παίκτης πηγαίνει στο σημείο
                }
            }
        }//right click
        else if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {

            stopMoving();

            ObjectClickedToLookOrExamine = null;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                if (target != null)
                {
                    ObjectClickedToLookOrExamine = target;//πρώτα θα γυρνάει προς το μέρος του αντικειμένου και μετά θα κάνει examine
                    setDirectionToFace(target.transform.position);
                    
                }
                else
                {
                    setDirectionToFace(hit.point);
                    string[] nothingThereStr = new string[1];
                    nothingThereStr[0] = "Δεν υπάρχει τίποτα εκεί";

                    Managers.Dialogue.StartDescription(nothingThereStr);
                }
            }
        }
    }

    public void setDirectionToFace(Vector3 directionToface)
    {
        isTurningToLookOrExamine = true;
        direcToTurn = directionToface - transform.position;
        direcToTurn.y = 0;
    }
    public void stopMoving()
    {
        character.Move(Vector3.zero, false, false);
        agent.SetDestination(transform.position);
        DistanceAddedToRemainingDistanceToActFrom = 0;
    }
}
