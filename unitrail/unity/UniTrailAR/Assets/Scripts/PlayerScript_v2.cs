using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
public class PlayerScript_v2 : MonoBehaviour
{
    // add text field for the number of touches on the screen
    [SerializeField]
    private TextMeshProUGUI touchCount;
    // add a variable for a target
    [SerializeField]
    private GameObject target1;
    [SerializeField]
    private GameObject target2;
    [SerializeField]
    private GameObject target3;
    [SerializeField]
    private Button setTargetButton1;
    [SerializeField]
    private Button setTargetButton2;
    [SerializeField]
    private Button setTargetButton3;
    // create a nav mesh agent
    private NavMeshAgent agent;
    // add a variable to hold the number of touches
    private int touchCountInt;
    // add a variable for the line renderer
    private LineRenderer line;
    // add a variable for a button to set the target

    // Start is called before the first frame update
    void Start()
    {
        touchCountInt = 0;
        // set the initial number of touches
        SetTouchCount();
        // get the nav mesh agent
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();

        // set the line renderer initial values
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.positionCount = 0;

        // set the button listeners
        setTargetButton1.GetComponent<Button>().onClick.AddListener(() => SetDestination(target1.transform.position));
        setTargetButton2.GetComponent<Button>().onClick.AddListener(() => SetDestination(target2.transform.position));
        setTargetButton3.GetComponent<Button>().onClick.AddListener(() => SetDestination(target3.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        // check for a touch on the screen and increment the number of touches
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            IncrementTouchCount();
        }

        if (agent.hasPath)
        {
            DrawPath();
        }
    }

    // add a function to set the initial number of touches
    private void SetTouchCount()
    {
        touchCount.text = touchCountInt.ToString();
    }

    // add a function to increment the number of touches
    private void IncrementTouchCount()
    {
        touchCountInt++;
        touchCount.text = touchCountInt.ToString();
    }

    // add a function to set the navigation target
    private void SetNavigationTarget()
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
        // SetDestination(target.transform.position);
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
