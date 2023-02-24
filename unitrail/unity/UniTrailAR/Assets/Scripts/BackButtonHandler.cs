using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    private int previousSceneIndex;

    void Start()
    {
        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex", 0);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        Time.timeScale = 0;
        if (Application.platform == RuntimePlatform.Android && pauseStatus)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("previousSceneIndex", SceneManager.GetActiveScene().buildIndex);
    }

    
}
