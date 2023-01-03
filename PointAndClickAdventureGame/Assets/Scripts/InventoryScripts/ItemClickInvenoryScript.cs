using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickInvenoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemClicked()
    {
        if (GetComponent<ItemInvComponent>().itemClass.nameObj.Length>1)
        {
            string itemName = GetComponent<ItemInvComponent>().itemClass.nameObj;
            int Id = GetComponent<ItemInvComponent>().getIdInvNum();
            Texture2D IconItemCursor = Resources.Load<Texture2D>("CursorItems/" + itemName + "Cursor");
            Sprite _spriteSet = Resources.Load<Sprite>("ItemIcons/" + itemName);
            Managers.Inventory.SetEquipedItem(itemName, Id);
            Managers.UI_Manager.setCursorToItemIconAndUse(IconItemCursor);
            string commandStr = "";
            commandStr = "χρησιμοποίησε ";

            commandStr += GetComponent<ItemInvComponent>().itemClass.nameObjWithArticle;
            string mestr = " με ";
            commandStr += mestr;
            Managers.Dialogue.EnableMainTextCommand(commandStr);
        }
    }
}
