using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static SceneManager Scene { get; private set; }
    public static UIManager UI_Manager { get; private set; }
    public static DialogueManager Dialogue { get; private set; }
    private List<GameManager> _startSequence;
    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Scene = GetComponent<SceneManager>();
        UI_Manager = GetComponent<UIManager>();
        Dialogue = GetComponent<DialogueManager>();
        _startSequence = new List<GameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
        _startSequence.Add(Scene);
        _startSequence.Add(Scene);
        _startSequence.Add(UI_Manager);
        _startSequence.Add(Dialogue);
        StartCoroutine(StartupManagers());//coroutine so that it will run asynchronously, with other parts of the game proceeding too(for example, a progress bar animated on a startup screen).
    }
    private IEnumerator StartupManagers()
    {
        foreach (GameManager manager in _startSequence)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = _startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (GameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);

            yield return null;
        }
        Debug.Log("All managers started up");
    }
}