using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class PlayerController : MonoBehaviour
{
    public ARCameraManager arCameraManager;
    private NavMeshAgent agent;
    private LineRenderer line;
    private Transform target;
    void Start()
    {
        Debug.Log("Player start...");
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
        target = GameObject.Find(PlayerPrefs.GetString("end")).transform;
        agent.SetDestination(target.position);
    }

    void Update()
    {
        Transform cameraTransform = arCameraManager.GetComponent<Camera>().transform;
        Quaternion cameraRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = cameraRotation;

        if (agent.hasPath)
        {
            DrawPath();
        }
    }

    void DrawPath()
    {
        line.positionCount = agent.path.corners.Length;
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        line.SetPosition(0, transform.position);

        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y + 1.5f, agent.path.corners[i].z);
            line.SetPosition(i, pointPosition);
        }
    }
}
