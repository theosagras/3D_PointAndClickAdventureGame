using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    private List<GameManager> _startSequence;
    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        _startSequence = new List<GameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
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