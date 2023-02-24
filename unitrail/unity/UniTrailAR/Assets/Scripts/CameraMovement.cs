using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectToLookAt;
    public float cameraDistance = 10.0f;
    public float cameraHeight = 2.0f;
    public float cameraRotationSpeed = 5.0f;
    public float swipeSpeed = 1.0f;

    private float currentRotationAngle = 0;
    private float swipeDistance;
    private Vector2 swipeStartPosition;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            swipeStartPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 currentSwipePosition = Input.GetTouch(0).position;
            swipeDistance = currentSwipePosition.x - swipeStartPosition.x;

            float swipeRatio = swipeDistance / Screen.width;
            float swipeAngle = swipeRatio * swipeSpeed;

            currentRotationAngle += swipeAngle * cameraRotationSpeed;

            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            Vector3 cameraPosition = objectToLookAt.position - currentRotation * Vector3.forward * cameraDistance;
            cameraPosition.y = objectToLookAt.position.y + cameraHeight;

            transform.position = cameraPosition;
            transform.LookAt(objectToLookAt.position);
        }
    }
}
