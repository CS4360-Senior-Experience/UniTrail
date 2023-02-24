using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class ImageTrackingHandler : MonoBehaviour
{
    private ARTrackedImageManager m_TrackedImageManager;
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

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // display message in debug text of image added and name of image
            debugText.text = "Image added: " + newImage.referenceImage.name;
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // display message in debug text of image updated and name of image
            debugText.text = "Image updated: " + updatedImage.referenceImage.name;
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // display message in debug text of image removed and name of image
            debugText.text = "Image removed: " + removedImage.referenceImage.name;
        }
    }
}