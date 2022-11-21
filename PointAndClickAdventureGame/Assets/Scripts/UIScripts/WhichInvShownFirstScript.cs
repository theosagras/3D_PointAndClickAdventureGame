using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichInvShownFirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _setWhichInvShownFirst(int i)
    {
        
        Managers.Inventory.setWhichInvShownFirst(i);
        int _WhichInvShownFirst = Managers.Inventory.getWhichInvShownFirst();
        int _CountItems = Managers.Inventory.getCountItems();

        if (_WhichInvShownFirst == 0)
        {
            Managers.Inventory.setLeftInvButton(false);
        }
        else Managers.Inventory.setLeftInvButton(true);

        if (_CountItems - _WhichInvShownFirst <= 8)
        {
            Managers.Inventory.setRightInvButton(false);
        }
        else if (_CountItems - _WhichInvShownFirst > 8)
        {
            Managers.Inventory.setRightInvButton(true);
        }
        
    }
}
