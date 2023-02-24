using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;

// [RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
// [RequireComponent(typeof(XROrigin))]
public class PlayerScript_v3 : MonoBehaviour
{
    // [SerializeField]
    // private GameObject target;
    // private GameObject spawnPoint;
    private NavMeshAgent agent;
    private int touchCountInt;
    private LineRenderer line;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // touchCountInt = 0;
        // set the initial number of touches
        // SetTouchCount();
        // get the nav mesh agent
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();

        // set the line renderer initial values
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.positionCount = 0;

        // get spawn location
        // spawnPoint = GameObject.Find("AES_Room_210");
        // spawn player
        // SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // check for a touch on the screen and increment the number of touches
        // if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        // {
        //     IncrementTouchCount();
        //     // SetNavigationTarget();
        // }

        if (agent.hasPath)
        {
            DrawPath();
        }
        // arPointCloud = arSessionOrigin.trackablesParent.GetComponentInChildren<ARPointCloud>();
    }

    // private void SpawnPlayer()
    // {
    //     // spawn player at spawn point
    //     transform.position = spawnPoint.transform.position;
    // }

    // add a function to set the initial number of touches
    // private void SetTouchCount()
    // {
    //     touchCount.text = touchCountInt.ToString();
    // }

    // add a function to increment the number of touches
    // private void IncrementTouchCount()
    // {
    //     touchCountInt++;
    //     touchCount.text = touchCountInt.ToString();
    // }

    // add a function to set the navigation target
    public void SetNavigationTarget(Transform target)
    {
        // // create a ray from the camera to the touch position
        // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        // // create a variable to hold the hit information
        // RaycastHit hit;
        // // check if the ray hits something
        // if (Physics.Raycast(ray, out hit))
        // {
        //     // set the navigation target
        //     SetDestination(hit.point);
        // }
        SetDestination(target.position);
    }

    // add a funtion to see the destination
    private void SetDestination(Vector3 target)
    {
        // set the destination
        agent.SetDestination(target);
    }

    void DrawPath()
    {
        line.positionCount = agent.path.corners.Length;
        line.SetPosition(0, transform.position);

        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < agent.path.corners.Length; i++)
        {
            // set point position to the current corner
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y + 0.5f, agent.path.corners[i].z);
            line.SetPosition(i, pointPosition);
        }
    }
}
