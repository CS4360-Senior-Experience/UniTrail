using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public float minFov = 5f;
    public float maxFov = 90f;
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    void Start(){
    cam = GetComponent<Camera>();
    }

    void Update(){
        // If there are two touches on the device...
        if (Input.touchCount == 2){
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Otherwise change the field of view based on the change in distance between the touches.
            cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 0 and 180.
            cam.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFov, maxFov);
            
        }
    }
}
