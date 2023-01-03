using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveDataClass
{
    public string nameOfScene;
    public string[] items;
    public string[] nameObjWithArticle;
    public string[][] description;
    public float[] playerPos;
    public float[] playerRot;
    public string[] _ItemsRemovedFromScenes;



    public SaveDataClass()
    {
        nameOfScene = SceneManager.GetActiveScene().name;
        playerPos = new float[3];
        playerRot = new float[3];
        items = Managers.Inventory.GetItemNameList().ToArray();

        List<string> itemRemoveList = new List<string>();
        itemRemoveList = Managers.Inventory.getItemsRemovedFromScenes();
        _ItemsRemovedFromScenes = itemRemoveList.ToArray();

        List<ItemClass> itemClassList = new List<ItemClass>();
        itemClassList = Managers.Inventory.GetItemClassList();

        List<string> nameItemWithArticleList = new List<string>();    

        foreach (ItemClass iC in itemClassList)
        {
            nameItemWithArticleList.Add(iC.nameObjWithArticle);
        }
        nameObjWithArticle = nameItemWithArticleList.ToArray();

        List<string[]> descriptionList = new List<string[]>();
        int countItems = Managers.Inventory.getCountItems();
        
        for (int i = 0; i < Managers.Inventory.getCountItems(); i++)
        {
            descriptionList.Add(itemClassList[i].description);

        }
        description = descriptionList.ToArray();

        playerPos[0] = Managers.Player.playerControl.transform.position.x;
        playerPos[1] = Managers.Player.playerControl.transform.position.y;
        playerPos[2] = Managers.Player.playerControl.transform.position.z;
        playerRot[0] = Managers.Player.playerControl.transform.eulerAngles.x;
        playerRot[1] = Managers.Player.playerControl.transform.eulerAngles.y;
        playerRot[2] = Managers.Player.playerControl.transform.eulerAngles.z;
    }
    
}
