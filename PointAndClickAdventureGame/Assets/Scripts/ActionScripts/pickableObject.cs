using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickableObject : MonoBehaviour
{
    [SerializeField] Sprite Icon;
    [SerializeField] float timeToPickAfterAnim;//πόσα δευτερόλεπτα μέχρι να πάει στο inv, εξαρτάται από το anim
    [SerializeField] Texture2D CursorIconItem;
    [SerializeField] float distanceFromObjToAct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void act()
    {
        Debug.Log("PickedUp");
        Managers.Inventory.InvGoDownForced();
        Managers.Player.setAnimToPlay("PickUp");
        StartCoroutine(pickUpAfterAnim());
       
    
    }
    public float _getDistanceToActFrom()
    {
        return distanceFromObjToAct;
    }

    IEnumerator pickUpAfterAnim()
    {
        yield return new WaitForSeconds(timeToPickAfterAnim);
        InteractableObject parentObj = GetComponent<InteractableObject>();
        if (Managers.Inventory.getCountItems() > 7)
        {
            if (Managers.Inventory.getCountItems()-Managers.Inventory.getWhichInvShownFirst()==8)//κίνηση μία θέση δεξιά το inventory
            {
                Managers.Inventory.InvMoveRight();
                Managers.Inventory.setLeftInvButton(true);

            }
            else
                if (Managers.Inventory.getCountItems() - Managers.Inventory.getWhichInvShownFirst() == 9)//κίνηση δύο θέσεις δεξιά το inventory
            {
                Managers.Inventory.InvMove2Right();
            }

        }

        Managers.Inventory.AddItem(parentObj.getName(), parentObj.getNameObjWithArticle(), parentObj.description, Icon, timeToPickAfterAnim, CursorIconItem);
        Managers.Inventory.DisplayItems();
       Managers.Scene.UpdateNavMesh();
        Managers.UI_Manager.setCursorTodefault();
        Managers.Player.playerControl.SetAnimPlayerIsPlaying(false);
        Destroy(gameObject);

    }




}
