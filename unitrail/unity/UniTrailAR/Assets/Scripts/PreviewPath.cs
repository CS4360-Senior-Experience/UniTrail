using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PreviewPath : MonoBehaviour
{
    private NavMeshPath path;
    private LineRenderer line;
    public GameObject start;
    public GameObject navTargetObject;
    private Vector3 lineHeightStart;
    private Vector3 lineHeightDestination;
    void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        lineHeightStart = new Vector3(start.transform.position.x,start.transform.position.y + 1.5f,start.transform.position.z);
        lineHeightDestination = new Vector3(navTargetObject.transform.position.x,navTargetObject.transform.position.y + 1.5f,navTargetObject.transform.position.z);
        PlayerPrefs.SetString("start", start.name);
        PlayerPrefs.SetString("end", navTargetObject.name);
        int previewSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousSceneIndex", previewSceneIndex);
    }

    void Update()
    {
       
        NavMesh.CalculatePath(lineHeightStart, lineHeightDestination, NavMesh.AllAreas, path);
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
        line.enabled = true;
    }
    public void SetNagivationTarget(string start, string end){
        // Find object name

    }


}
