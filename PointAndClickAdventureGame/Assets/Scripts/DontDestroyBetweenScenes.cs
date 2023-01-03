using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        if (FindGameObjectsWithSameName(gameObject.name) > 1)
        {
            if ((gameObject.name=="Πόρτα")||
                (gameObject.name == "Exit"))
             Destroy(gameObject);
        }



    }

    private int FindGameObjectsWithSameName(string name)
    {
        GameObject[] allObjs = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> likeNames = new List<GameObject>();
        foreach (GameObject obj in allObjs)
        {
            if (obj.name == name)
            {
                likeNames.Add(obj);
            }
        }
        return likeNames.Count;
    }




    // Update is called once per frame

}
