using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnLoadSceneScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LoadingScreen;
    public Image LoadingBar;
    
  
    public void LoadScene(string sceneName)
    {
        Managers.Scene.LoadScene(sceneName);
    }


}
