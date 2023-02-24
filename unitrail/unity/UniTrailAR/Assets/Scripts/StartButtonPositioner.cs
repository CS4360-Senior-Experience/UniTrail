using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonPositioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 screenPosition = new Vector3(Screen.width - 212, 176, 0);
        transform.position = screenPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
