using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotateModel : MonoBehaviour
{
    // Variables for rotating the ob
    private float rotationSpeed = 0.1f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);
            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, 0f, -touch0.deltaPosition.x * rotationSpeed);
                
            }
 
        }
    }
}