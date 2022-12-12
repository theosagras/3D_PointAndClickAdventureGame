using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemRightClickInventoryScript : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initiates whenever the pointer is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Destroys item from players inventory when pressed
        if (eventData.pointerId == -2)
        {
            if (GetComponent<ItemInvComponent>().name != null)
            {
                string[] descrip = GetComponent<ItemInvComponent>().description;
                Managers.Dialogue.StartDescription(descrip);

            }
        }
    }
}

