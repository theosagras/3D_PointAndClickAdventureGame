using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, GameManager
{

    public ManagerStatus status { get; private set; }
    private Dictionary<string, ItemClass> _items;//το value είναι η θέση στο inventory
    public Animator invAnimLeftRight;
    public Button[] invButtons;
    public int WhichInvShownFirst = 0;
    public Button leftInvButton;
    public Button rightInvButton;
    public Button equippedInvButton;
    private bool invIsUp;
    public Animator invAnim;
    public SpriteRenderer spriteRendererCursorItem;
    private string equippedItem { get; set; }
    private int numOfInvBtnClicked;
    List <string> ItemsRemovedFromScenes=new List<string>();
    public void Startup()
    {
        _items = new Dictionary<string, ItemClass>();
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
        foreach (KeyValuePair<string, ItemClass> item in _items)
        {
            itemDisplay += item.Key + " (" + item.Value.nameObj + ") ";

        }
        Debug.Log(itemDisplay);
    }
    public void AddItem(ItemClass itemToAddClass)//,string nameObjWithArticle, string[] desc,Sprite sprite,float timeToPickAfterAnim, Texture2D ItemIconCursor
    {
        if (_items.ContainsKey(itemToAddClass.nameObj))
        {
        }
        else
        {
            _items.Add(itemToAddClass.nameObj, itemToAddClass);

            invButtons[_items.Count - 1].GetComponent<ItemInvComponent>().itemClass = itemToAddClass;
            invButtons[_items.Count - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemIcons/" + itemToAddClass.nameObj);
            AddItemToItemsRemovedFromScenes(itemToAddClass.nameObj);
        }
    }
    public List<string> GetItemNameList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }
    public List<ItemClass> GetItemClassList()
    {
        List<ItemClass> itemClassList = new List<ItemClass>();
        foreach (ItemClass iC in _items.Values)
        {
            itemClassList.Add(iC);
        }
        return itemClassList;
    }


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


    public void SetEquipedItem(string itemEquipped, int _numOfInvBtnClicked)
    {
        equippedInvButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemIcons/" + itemEquipped);
        equippedItem = itemEquipped;
        numOfInvBtnClicked = _numOfInvBtnClicked;
    }
    public void SetNumOfInvBtnClicked(int _numOfInvBtnClicked)
    {
        numOfInvBtnClicked = _numOfInvBtnClicked;
    }

    public void unEquipedItem()
    {
        equippedInvButton.GetComponent<Image>().sprite = null;
        equippedItem = null;
        numOfInvBtnClicked = -1;
        Managers.UI_Manager.setCursorTodefault();
    }
    public string getEquppedItemName()
    {

        return equippedItem;
    }
    public int getNumOfInvBtnClicked()
    {

        return numOfInvBtnClicked;
    }

    public void removeItem(string itemNameToRemove)
    {

        unEquipedItem();
        _items.Remove(itemNameToRemove);
        updateInventory();


    }
    private void updateInventory()
    {
        int i = 0;
        foreach (KeyValuePair<string, ItemClass> keyValue in _items)
        {

            invButtons[i].GetComponent<ItemInvComponent>().itemClass = keyValue.Value;
            invButtons[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemIcons/" + keyValue.Key);
            i++;
        }
        for (int j = i; j < 15; j++)
        {
            invButtons[j].GetComponent<ItemInvComponent>().itemClass = null;
            invButtons[j].GetComponent<Image>().sprite = null;
        }

    }

    public void RemoveAllItems()
    {
        _items.Clear();
        ItemsRemovedFromScenes.Clear();
    }
    public void InsertItemsFromSaveFile(SaveDataClass sDC)
    {
        for (int i=sDC.items.Length;i>0;i--)
        {
            ItemClass iC = new ItemClass();
            iC.nameObj = sDC.items[i-1];
            iC.nameObjWithArticle = sDC.nameObjWithArticle[i-1];
            iC.description = sDC.description[i-1];
            _items.Add(iC.nameObj, iC);
            updateInventory();
        }
    }

    //Η παρακάτω λίστα χρησιμευεί όταν γίνεται load ενός αποθηκευμένου παιχνιδιού να αφαιρούνται αντικείμενα που δεν πρέπει να υπάρχουν στην σκηνή.
    public void AddItemToItemsRemovedFromScenes(string itemName)
    {
        ItemsRemovedFromScenes.Add(itemName);
    }
    public List<string> getItemsRemovedFromScenes()
    {
        return ItemsRemovedFromScenes;
    }

    public void setListItemsRemovedFromScenes(List<string> listItemToRemove)
    {

        ItemsRemovedFromScenes = listItemToRemove;
    }
    public bool checkIfItemIsInRemoveList(string nameItem)
    {
        if (ItemsRemovedFromScenes.Contains(nameItem))
        {
            return true;
        }
        else return false;
    }


}
