using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTitlePositioner : MonoBehaviour
{
    private Vector3 titlePosition;
    void Start()
    {
        titlePosition = new Vector3(Screen.width / 2, Screen.height - 200, 0);
        transform.position = titlePosition;
    }
}
