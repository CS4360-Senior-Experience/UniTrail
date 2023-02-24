using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;


public class SpawnController : MonoBehaviour
{
    // XROrigin xrOrigin;
    private Transform spawnPoint;
    private Transform target;
    private Transform xrOrigin;
    private string start;
    private string end;

    // called zero
    void Awake()
    {
        Debug.Log("Awake");
        start = PlayerPrefs.GetString("start");
        end = PlayerPrefs.GetString("end");
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        spawnPoint = GameObject.Find(start).transform;
        target = GameObject.Find(end).transform;
        xrOrigin = GameObject.Find("XR Origin").transform;

        // if (player != null)
        // {
        //     Debug.Log("Player found");
        // }
        // else
        // {
        //     Debug.Log("Player not found");
        // }
        if (spawnPoint != null)
        {
            Debug.Log("Spawn point found");
        }
        else
        {
            Debug.Log("Spawn point not found");
        }
        if (target != null)
        {
            Debug.Log("Target found");
        }
        else
        {
            Debug.Log("Target not found");
        }
        // if (agent != null)
        // {
        //     Debug.Log("Agent found");
        // }
        // else
        // {
        //     Debug.Log("Agent not found");
        // }
        
        xrOrigin.position = spawnPoint.position;
    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }


    void Update()
    {

    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}