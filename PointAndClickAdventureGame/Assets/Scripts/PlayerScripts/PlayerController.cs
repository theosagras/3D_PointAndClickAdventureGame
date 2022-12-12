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
    private float initialAgentsSpeed;
    public ThirdPersonCharacter character;
    private int leftClickedPressedTimes;
    private float firstLeftClickTime;
    private float timeFirstTosSecondClick = 0.5f;

    InteractableObject ObjectClicked;
    float DistanceAddedToRemainingDistanceToActFrom;
    bool facingTarget;
    bool rightClicked;
    Vector3 direcToTurn;

    public GameObject PrefabClickParticles;//εμφανίζεται όταν κάνεις αριστερό κλικ
    private GameObject ClickParticleInstatiated;
    private bool AnimPlayerIsPlaying;
    private Vector3 directionToFace;
    bool arrivedDest;
    void Start()
    {
        agent.updateRotation = false ;
        initialAgentsSpeed = Managers.Player.playerControl.agent.speed;
    }

    private void RotateTowards(Vector3 targetV3)
    {
        Vector3 direction = (targetV3 - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 4.5f);
        if (Mathf.Abs(lookRotation.eulerAngles.y - transform.rotation.eulerAngles.y) < 2)
        {
            //transform.rotation = lookRotation;
            if (!rightClicked)
            {
                if (ObjectClicked != null)
                {
                    ObjectClicked.act();
                    facingTarget = false;
                    ObjectClicked = null;
                    stopMoving();
                }

            }
            else//αν είχε πατηθεί δεξί κλικ κάνει examine
            {
                facingTarget = true;
            }
           
           
            
        }
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Managers.Inventory.DisplayItems();
        }

        if (agent.remainingDistance > agent.stoppingDistance + DistanceAddedToRemainingDistanceToActFrom)//Κινείται προς προορισμό αν απέχει από αυτόν
        {
            

            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            agent.SetDestination(transform.position);

            if (rightClicked)
            {
                if (!facingTarget)
                    RotateTowards(directionToFace);
                else
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
                    stopMoving();
                }

            }
            //έφτασε στον προορισμό
            else
            {
                
                if (ObjectClicked == null)//αν δεν υπάρχει αντικείμενο στόχου
                    stopMoving();
                else
                {
                    if (!facingTarget)
                    {
                        character.Move(Vector3.zero, false, false);
                        //agent.SetDestination(transform.position);
                        RotateTowards(ObjectClicked.transform.position);
                    }

                    else
                    {
                        // character.Move(Vector3.zero, false, false);
                        facingTarget = false;
                    }

                }
            }
        }
         /*

            else if ((isTurning) && (!facingTarget))//Ο παίκτης περιστρέφεται προς στόχο 
            {
                Vector3 direction = (directionToFace - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

                Debug.Log(Quaternion.Dot(transform.rotation, lookRotation));
                Debug.Log("gonia");
                Debug.Log(lookRotation.eulerAngles.y);
                Debug.Log(transform.rotation.eulerAngles.y);
                if (Mathf.Abs(lookRotation.eulerAngles.y - transform.rotation.eulerAngles.y)<1)
               // if (Mathf.Abs(Quaternion.Dot(transform.rotation, lookRotation))>0.99f)// να ο παίκτης κοιτάει προς στόχο τότε θα κάνει 
                {
                    transform.rotation = lookRotation;
                    isTurning = false;
                    facingTarget = true;
                }
                //transform.rotation = rot;
               // Debug.Log(Quaternion.Dot(transform.rotation, rot));
                
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
    */
        //left mouse click
        if (Input.GetMouseButtonDown(0) && !AnimPlayerIsPlaying && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {
            Managers.Player.playerControl.agent.speed = initialAgentsSpeed;
            leftClickedPressedTimes++;
          
            if (leftClickedPressedTimes==1)
            {
                firstLeftClickTime = Time.time;
                StartCoroutine(DetectDoubleClicked());
            }

            stopMoving();
            Managers.Inventory.InvGoUpForced();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                showParticleAfterClick(hit.point);
                Managers.UI_Manager.clickShowCircle();
                
                GameObject hitObject = hit.transform.gameObject;
                InteractableObject target = hitObject.GetComponent<InteractableObject>();
                if (target != null)
                {
                    ObjectClicked = target;  //θα κάνει ενέργεια όταν φτάσει στο σημείο που βρίσκεται το αντικείμενο και έχει γυρίσει προς το μέρος του
                    DistanceAddedToRemainingDistanceToActFrom = target.getDistanceToActFrom();
                    if (Vector3.Distance(hit.point, transform.position)> agent.stoppingDistance + DistanceAddedToRemainingDistanceToActFrom)//διορθώνει ένα μικρό τσούλισμα του παίκτη που έκανε χωρίς λόγο
                     agent.SetDestination(target.getWaypointIfExistsOtherwiseObjectsPos());
                }
                else//έχει γίνει κλικ σε μη interactable σημείο
                {
                    if (Managers.Inventory.equippedInvNum == -1) //αν δεν έχει equip item
                    {
                        DistanceAddedToRemainingDistanceToActFrom = 0;
                        agent.SetDestination(hit.point);//απλά ο παίκτης πηγαίνει στο σημείο
                    }
                    else//αν έχει equipped item
                    {
                        Managers.Dialogue.StartDialogue(5);
                        Managers.UI_Manager.setCursorTodefault();
                        Managers.Inventory.unEquipedItem();
                        Managers.Dialogue.DisableMainTextCommand();
                        stopMoving();

                    }
                }
            }
        }//right click
        else if (Input.GetMouseButtonDown(1) && !AnimPlayerIsPlaying && !EventSystem.current.IsPointerOverGameObject())//όχι όταν πατάς πάνω σε ui element (πχ διαλόγους)
        {
            if (Managers.Inventory.equippedInvNum != -1)
                Managers.Inventory.unEquipedItem();
            Managers.Dialogue.DisableMainTextCommand();
            
            DistanceAddedToRemainingDistanceToActFrom = 100;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                showParticleAfterClick(hit.point);
                Managers.UI_Manager.clickShowCircle();
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
    private IEnumerator DetectDoubleClicked()
    {
        while (Time.time<firstLeftClickTime+ timeFirstTosSecondClick)
        {
            if (leftClickedPressedTimes==2)
            {
                Managers.Player.playerControl.agent.speed *= 2;
                break;
               
            }
            yield return new WaitForSeconds(0);
        }
        leftClickedPressedTimes = 0;
       
    }
    public void setDirectionToFace(Vector3 _directionToface)
    {
        
        directionToFace = _directionToface;
        Vector3 direction = (directionToFace - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        if (Mathf.Abs(lookRotation.eulerAngles.y - transform.rotation.eulerAngles.y) > 2)
            facingTarget = false;
        else
            facingTarget = true;


    }
    public void stopMoving()
    {
        
        character.Move(Vector3.zero, false, false);
        agent.SetDestination(transform.position);

        arrivedDest = false;
        ObjectClicked = null;
        rightClicked = false;
        facingTarget = false;
    }

    public void SetAnimPlayerIsPlaying(bool _AnimPlayerIsPlaying)
    {
        AnimPlayerIsPlaying = _AnimPlayerIsPlaying;
    }
    void showParticleAfterClick(Vector3 point)
    {
        Vector3 pointOfParticle;//εμφανίζεται ένα particlesystem όταν κάνεις κλικ κάπου. Μετακινείται λίγο προς την κάμερα για να φαίνεται ολόκληρο
        pointOfParticle = point + (Camera.main.transform.forward * -0.1f);

        ClickParticleInstatiated = Instantiate(PrefabClickParticles, pointOfParticle, Quaternion.identity);
        Destroy(ClickParticleInstatiated, 1);
    }

}
