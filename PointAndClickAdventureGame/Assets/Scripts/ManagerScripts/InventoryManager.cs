using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, GameManager
{

    public ManagerStatus status { get; private set; }
    private Dictionary<string, string[]> _items;
    public Animator invAnimLeftRight;
    public Button[] invButtons;
    public int WhichInvShownFirst=0;
    public Button leftInvButton;
    public Button rightInvButton;
    public Button equippedInvButton;
    private bool invIsUp;
    public Animator invAnim;
    public SpriteRenderer spriteRendererCursorItem;
    Sprite cursorItemSprite;
    public int equippedInvNum { get; set; }// -1 no equpped item,  0-14 equipped
    public void Startup()
    {
        equippedInvNum = -1;
        _items = new Dictionary<string, string[]>();
        Debug.Log("Inventory manager starting...");
        status = ManagerStatus.Started;
     
    }
  
    public void InvBtnPressed()
    {
        if (!invIsUp)//να κατεβει το inv
        {
            InvGoUpForced();
        }

        else //να ανεβεί το inv
        {
            InvGoDownForced();
        }
    }
    public void InvGoUpForced()
    {
        invAnim.SetBool("goUp1", true);
        invAnim.SetBool("goDown1", false);
        invIsUp = true;
       
    }
    public void InvGoDownForced()
    {
        invAnim.SetBool("goUp1", false);
        invAnim.SetBool("goDown1", true);
        invIsUp = false;
    }

    public void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, string[]> item in _items)
        {
            itemDisplay += item.Key + " (";
            foreach (string aa in item.Value)
            {
                itemDisplay += aa;
                itemDisplay += ") ";
            }
        }
        Debug.Log(itemDisplay);
    }
    public void AddItem(string name,string nameObjWithArticle, string[] desc,Sprite sprite,float timeToPickAfterAnim, Texture2D ItemIconCursor)
    {
        if (_items.ContainsKey(name))
        {

        }
        else
        {
            _items.Add(name, desc);
            cursorItemSprite = sprite;
            invButtons[_items.Count-1].GetComponent<Image>().sprite = sprite;
            invButtons[_items.Count - 1].GetComponent<ItemInvComponent>().SetProperties(sprite, name, nameObjWithArticle, desc, timeToPickAfterAnim, ItemIconCursor);
            
        }
    }
    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }
    /*
    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }
    */

    public void InvMoveRight()
    {
        invAnimLeftRight.SetTrigger("MoveRight");
        invAnimLeftRight.ResetTrigger("MoveLeft");
        invAnimLeftRight.ResetTrigger("Move2Right");
        invAnimLeftRight.ResetTrigger("Move2Left");
    }
    public void InvMove2Right()
    {
        invAnimLeftRight.SetTrigger("Move2Right");
        invAnimLeftRight.ResetTrigger("MoveLeft");
        invAnimLeftRight.ResetTrigger("MoveRight");
        invAnimLeftRight.ResetTrigger("Move2Left");
    }
    public void InvMoveleft()
    {
        invAnimLeftRight.SetTrigger("MoveLeft");
        invAnimLeftRight.ResetTrigger("MoveRight");
        invAnimLeftRight.ResetTrigger("Move2Right");
        invAnimLeftRight.ResetTrigger("Move2Left");
    }

    public void setWhichInvShownFirst(int _WhichInvShownFirst)
    {
        WhichInvShownFirst = _WhichInvShownFirst;
    }
    public int getWhichInvShownFirst()
    {
        return WhichInvShownFirst;
    }
    public int getCountItems()
    {
        return _items.Count;
    }

    public void setLeftInvButton(bool onOff)
    {
        leftInvButton.interactable = onOff;
    }
    public void setRightInvButton(bool onOff)
    {
        rightInvButton.interactable = onOff;
    }


    public void SetEquipedItem(Sprite spriteEquip, int invID)
    {
        equippedInvButton.GetComponent<Image>().sprite = spriteEquip;
        equippedInvNum = invID;
    }
    public void unEquipedItem()
    {
        equippedInvButton.GetComponent<Image>().sprite = null;
        equippedInvNum = -1;
        Managers.UI_Manager.setCursorTodefault();
    }
}
