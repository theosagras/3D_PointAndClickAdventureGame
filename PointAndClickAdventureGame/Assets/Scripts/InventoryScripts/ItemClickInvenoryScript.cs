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
        int i = GetComponent<ItemInvComponent>().getIdInvNum();
        Texture2D IconItemCursor= GetComponent<ItemInvComponent>().ItemIconCursorTexture;
        Sprite _spriteSet=GetComponent<Image>().sprite;
        Managers.Inventory.SetEquipedItem(_spriteSet, i);
        Managers.UI_Manager.setCursorToItemIconAndUse(IconItemCursor);
        string commandStr = "";
        commandStr = "χρησιμοποίησε ";

        commandStr += Managers.Inventory.invButtons[Managers.Inventory.equippedInvNum].GetComponent<ItemInvComponent>().nameObjWithArticle;
        string mestr = " με ";
        commandStr += mestr;
        Managers.Dialogue.EnableMainTextCommand(commandStr);
    }
}
