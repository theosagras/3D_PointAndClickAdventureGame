using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInvComponent : MonoBehaviour
{
    public ItemClass itemClass;
    public int idInvNum;
    

    // Start is called before the first frame update
    void Start()
    {
    }
    public int getIdInvNum()
    {
        return idInvNum;
    }
    // Update is called once per frame
    
    public void addItemToInv(ItemClass _itemClass)
    {
        itemClass = _itemClass;
       
    }
    public void remove()
    {
        itemClass = null;
    }

}
