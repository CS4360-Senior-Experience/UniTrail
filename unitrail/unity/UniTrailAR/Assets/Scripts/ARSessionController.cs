using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARSessionController : MonoBehaviour
{
    ARSession arSession;
    [SerializeField]
    private GameObject pauseOverlay;
    private bool isPaused = false;

    void Start()
    {
        arSession = GetComponent<ARSession>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ToggleARSession()
    {
        arSession.enabled = !arSession.enabled;
        Debug.Log("ARSession enabled: " + arSession.enabled);
    }

    public void TogglePauseOverlay()
    {
        // pauseOverlay = GameObject.Find("PauseOverlay");
        pauseOverlay.SetActive(!pauseOverlay.activeSelf);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        TogglePauseOverlay();
        // ToggleARSession();
    }

    public void ResumeGame()
    {
        isPaused = false;
        TogglePauseOverlay();
        // ToggleARSession();
        Time.timeScale = 1;
    }
}
