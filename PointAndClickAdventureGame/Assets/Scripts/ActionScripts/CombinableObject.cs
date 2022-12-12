using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinableObject : MonoBehaviour
{
    private string combineObj;
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

        string itemNameToCombine=Managers.Inventory.getEquppedItemName();
        Debug.Log("give");
        Combine(itemNameToCombine);
    }

    public virtual void Combine(string combObject)
    {

    }

}
