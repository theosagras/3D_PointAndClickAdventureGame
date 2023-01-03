using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineLogoScript : MonoBehaviour
{
    public GameObject LogoObj;
    public GameObject[] otherObjToActivateWhenFinish;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Autofinish());
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Escape))|| (Input.GetMouseButtonDown(0)))
        {
            Managers.Scene.setFadeToBlack();
            finishLogo();

        }
    }


    void finishLogo()
    {
        foreach (GameObject aaa in otherObjToActivateWhenFinish)
        {
            if (aaa != null)
                aaa.SetActive(true);
        }
       
        Managers.Scene.fadeIn();

        Destroy(LogoObj);
    }

    IEnumerator Autofinish()
    {
        yield return new WaitForSeconds(6.0f);
        finishLogo();
        
    }
}
