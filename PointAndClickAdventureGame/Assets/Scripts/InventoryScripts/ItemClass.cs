using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemClass
{
    public string nameObj;
    public string nameObjWithArticle;
    [TextArea(3, 10)]
    public string[] description;

    public ItemClass(string _nameObj, string _nameObjWithArticle, string[] _description)
    {
        nameObj = _nameObj;
        nameObjWithArticle = _nameObjWithArticle;
        description = _description;
    }
    public ItemClass()
    {

    }

}
