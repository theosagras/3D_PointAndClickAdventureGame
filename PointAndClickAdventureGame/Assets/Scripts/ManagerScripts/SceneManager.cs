using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class SceneManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public NavMeshSurface GroundNavMesh;
    public void Startup()
    {
        Debug.Log("SceneManager manager starting...");
        


        status = ManagerStatus.Started;
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

}