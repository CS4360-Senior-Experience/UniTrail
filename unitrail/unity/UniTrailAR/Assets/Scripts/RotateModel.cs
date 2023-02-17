using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    // Variables for rotating the ob
    public Transform objectToRotate;   
    private Vector2 swipeDirection;
    private float rotationSpeed = 0.2f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);
            swipeDirection = Input.GetTouch(0).deltaPosition;
            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                // objectToRotate.transform.Rotate(0f, touch0.deltaPosition.x, 0f);
                objectToRotate.transform.Rotate(swipeDirection.y * rotationSpeed, -swipeDirection.x * rotationSpeed, 0, Space.World);
            
            }
 
        }
    }
}
