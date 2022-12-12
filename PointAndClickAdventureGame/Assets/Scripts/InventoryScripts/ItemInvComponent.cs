using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInvComponent : MonoBehaviour
{
    public int idInvNum;
    public Sprite Icon;
    public string nameObj;
    public string nameObjWithArticle;
    [TextArea(3, 10)]
    public string[] description;
    public float timeToPickAfterAnim;//πόσα δευτερόλεπτα μέχρι να πάει στο inv, εξαρτάται από το anim
    public Texture2D ItemIconCursorTexture { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }
    public int getIdInvNum()
    {
        return idInvNum;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetProperties(Sprite _Icon, string _nameObj, string _nameObjWithArticle, string[] _description, float _timeToPickAfterAnim,Texture2D _ItemIconCursorTexture)
    {
        Icon = _Icon;
        nameObj = _nameObj;
        nameObjWithArticle = _nameObjWithArticle;
        description = _description;
        timeToPickAfterAnim = _timeToPickAfterAnim;//πόσα δευτερόλεπτα μέχρι να πάει στο inv, εξαρτάται από το anim
        ItemIconCursorTexture=_ItemIconCursorTexture;
    }
    public void remove()
    {
        Icon = null;
        nameObj = null;
        nameObjWithArticle = null;
        description = null;
        timeToPickAfterAnim = 0;//πόσα δευτερόλεπτα μέχρι να πάει στο inv, εξαρτάται από το anim
        ItemIconCursorTexture = null;
        GetComponent<Image>().sprite = null;
    }

}
