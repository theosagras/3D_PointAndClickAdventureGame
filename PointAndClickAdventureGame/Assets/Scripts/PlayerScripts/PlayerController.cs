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

    InteractableObject ObjectClicked;
    float DistanceAddedToRemainingDistanceToActFrom;
    bool isTurning;
    bool facingTarget;
    bool rightClicked;
    Vector3 direcToTurn;
    public GameObject InventoryGoUpBtn;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (agent.remainingDistance > agent.stoppingDistance + DistanceAddedToRemainingDistanceToActFrom)//Κινείται προς προορισμό αν απέχει από αυτόν
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            //έφτασε στον προορισμό
            if ((!isTurning) && (!facingTarget))//αν δεν κοιτάει προς στόχο
            {
                if (ObjectClicked == null)//αν δεν υπάρχει αντικείμενο στόχου
                    stopMoving();
                else
                    setDirectionToFace(ObjectClicked.transform.position);
            }

            else if ((isTurning) && (!facingTarget))//Ο παίκτης περιστρέφεται προς στόχο 
            {
                Quaternion rot = Quaternion.LookRotation(direcToTurn);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, 4.5f * Time.deltaTime);

                if (Mathf.Abs(Quaternion.Dot(transform.rotation, rot)) > 0.999f)// να ο παίκτης κοιτάει προς στόχο τότε θα κάνει 
                {
                    isTurning = false;
                    facingTarget = true;
                }
            }
            else if ((!isTurning) && (facingTarget))//Ο παίκτης κοιτάει τον στόχο
            {

                if (!rightClicked)
                {
                    if (ObjectClicked != null)
                    {
                        ObjectClicked.act();
                    }
                   
                }
                else//αν είχε πατηθεί δεξί κλικ κάνει examine
                {
                    if (ObjectClicked != null)
                    {
                        Managers.Dialogue.StartDescription(ObjectClicked.description);

                    }
                    else
                    {

                        string[] nothingThereStr = new string[1];
                        nothingThereStr[0] = "Δεν υπάρχει τίποτα εκεί";

                        Managers.Dialogue.StartDescription(nothingThereStr);
                    }
                }
                ObjectClicked = null;
                isTurning = false;
                stopMoving();
                facingTarget = false;

            }
            else
            {
                stopMoving();
            }
        }
        //left mouse click
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {
            stopMoving();
            Managers.UI_Manager.InvBtnPressedGoUp();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                if (target != null)
                {
                    ObjectClicked = target;  //θα κάνει ενέργεια όταν φτάσει στο σημείο που βρίσκεται το αντικείμενο και έχει γυρίσει προς το μέρος του
                    DistanceAddedToRemainingDistanceToActFrom = target.getDistanceToActFrom();
                    agent.SetDestination(target.getWaypointIfExistsOtherwiseObjectsPos());
                }
                else
                {
                    DistanceAddedToRemainingDistanceToActFrom = 0;
                    agent.SetDestination(hit.point);//απλά ο παίκτης πηγαίνει στο σημείο
                }
            }
        }//right click
        else if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {

            stopMoving();
            DistanceAddedToRemainingDistanceToActFrom = 100;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                ObjectClicked = target;
                rightClicked = true;
                if (target != null)
                    setDirectionToFace(ObjectClicked.transform.position);
                else
                    setDirectionToFace(hit.point);
            }
        }
    }

    public void setDirectionToFace(Vector3 directionToface)
    {
        isTurning = true;
        direcToTurn = directionToface - transform.position;
        direcToTurn.y = 0;
    }
    public void stopMoving()
    {
        character.Move(Vector3.zero, false, false);
        agent.SetDestination(transform.position);
        

        ObjectClicked = null;
        rightClicked = false;
        facingTarget = false;
        isTurning = false;
    }
}
