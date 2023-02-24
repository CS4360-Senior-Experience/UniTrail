using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ImageTrackingHandler_v2 : MonoBehaviour
{
    // this class will be used to get the image tracking manager and display debug messages to debug text UI if a tracked image is added, updated or removed

    // add a variable for the ARTrackedImageManager
    private ARTrackedImageManager m_TrackedImageManager;
    // add a variable for the debug text
    private TextMeshProUGUI debugText;

    // on awake get the ARTrackedImageManager
    void Awake()
    {
        m_TrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        // get the debug text
        debugText = GameObject.Find("DebugText").GetComponent<TextMeshProUGUI>();
    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    // add a function to handle the tracked images changed event
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // loop through the added images
        foreach (var trackedImage in eventArgs.added)
        {
            // display a debug message
            debugText.text = "Image added: " + trackedImage.referenceImage.name;
        }

        // loop through the updated images
        foreach (var trackedImage in eventArgs.updated)
        {
            // display a debug message
            debugText.text = "Image updated: " + trackedImage.referenceImage.name;
        }

        // loop through the removed images
        foreach (var trackedImage in eventArgs.removed)
        {
            // display a debug message
            debugText.text = "Image removed: " + trackedImage.referenceImage.name;
        }
    }
}
