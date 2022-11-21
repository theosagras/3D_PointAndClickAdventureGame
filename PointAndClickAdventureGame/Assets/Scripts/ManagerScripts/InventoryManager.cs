using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, GameManager
{

    public ManagerStatus status { get; private set; }
    private Dictionary<string, string[]> _items;
    public Animator invAnimLeftRight;
    public GameObject[] invButtons;
    public int WhichInvShownFirst=0;
    public Button leftInvButton;
    public Button rightInvButton;
    public void Startup()
    {
        _items = new Dictionary<string, string[]>();
        Debug.Log("Inventory manager starting...");
        status = ManagerStatus.Started;
     
    }

    public void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, string[]> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value[0]+"   "+item.Value[1] + ") ";
        }
        Debug.Log(itemDisplay);
    }
    public void AddItem(string name,string[] desc,Sprite sprite)
    {
        if (_items.ContainsKey(name))
        {

        }
        else
        {
            _items.Add(name, desc);
            invButtons[_items.Count-1].GetComponent<Image>().sprite = sprite;

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
}
