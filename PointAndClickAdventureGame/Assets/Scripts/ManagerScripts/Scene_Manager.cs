using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Scene_Manager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public NavMeshSurface GroundNavMesh;
    public string previousScene;
    public GameObject LoadingScreen;
    public Image LoadingBar;
    public Animator fadeAnimator;
    public Image fadeImage;
    public Button BtnLoadMainScreen;
    public Button BtnLoadPauseMenu;
    public void Startup()
    {
        Debug.Log("SceneManager manager starting...");     
        status = ManagerStatus.Started;
        string path = Application.persistentDataPath + "/saveFile";
        if (File.Exists(path))
        {
            BtnLoadMainScreen.interactable = true;
            BtnLoadPauseMenu.interactable = true;
        }
        else
        {
            BtnLoadMainScreen.interactable = false;
            BtnLoadPauseMenu.interactable = false;
        }
    }

    public void UpdateNavMesh()//after 2 secs
    {
        
        StartCoroutine(_UpdateNavMesh());
    }
    IEnumerator _UpdateNavMesh()
    {
        yield return new WaitForSeconds(1);
        GroundNavMesh.BuildNavMesh();

    }


    public void LoadScene(string sceneName)
    {
      
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBar.fillAmount = progressValue;
            yield return null;
        }
        LoadingScreen.SetActive(false);
        fadeAnimator.SetTrigger("fadein");
    }
    public void LoadScene(string sceneName,SaveDataClass _saveData)
    {

        StartCoroutine(LoadSceneAsync(sceneName, _saveData));
    }

    IEnumerator LoadSceneAsync(string sceneName, SaveDataClass _saveData)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBar.fillAmount = progressValue;
            yield return null;
        }
        LoadingScreen.SetActive(false);
        Debug.Log("rot=" + _saveData.playerRot[1]);
        Managers.Player.playerControl.transform.position = new Vector3(_saveData.playerPos[0], _saveData.playerPos[1], _saveData.playerPos[2]);
        Managers.Player.playerControl.transform.eulerAngles = new Vector3(_saveData.playerRot[0], _saveData.playerRot[1], _saveData.playerRot[2]);
        Managers.Player.playerControl.stopMoving();
       fadeAnimator.SetTrigger("fadein");

    }


    public void fadeIn()
    {
        fadeAnimator.SetTrigger("fadein");
    }

    public void setFadeToBlack()
    {


        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
    }



    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveFile";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveDataClass data = new SaveDataClass();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadGame()
    {
        string path = Application.persistentDataPath + "/saveFile";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveDataClass data = formatter.Deserialize(stream) as SaveDataClass;
            stream.Close();

            Managers.Inventory.RemoveAllItems();
            Managers.Inventory.InsertItemsFromSaveFile(data);
            Managers.Scene.LoadScene(data.nameOfScene,data);

            List<string> itemRemoveList = new List<string>();
            foreach ( string ItemToRemove in data._ItemsRemovedFromScenes)
            {
                itemRemoveList.Add(ItemToRemove);
            }
            Managers.Inventory.setListItemsRemovedFromScenes(itemRemoveList);


           // return data;
        }
        else
        {
            Debug.Log("no save file to load");
        }
        

        
    }
}