using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;
 
 
public class PointNumberCount : MonoBehaviour
{
    // ARSessionOrigin arSessionOrigin;
    ARPointCloud arPointCloud;
    ARPointCloud arPointCloudVis;
    XROrigin arSessionOrigin;
    public ARPointCloudManager pointCloudManager;
 
    int totalNumber;
    List<Vector3> featurePoints = new List<Vector3>();
    List<ulong> uids = new List<ulong>();
    List<float> confs = new List<float>();
    List<ARPoint> addedPoints;
    List<ARPoint> updatedPoints;
 
    void Start()
    {
        // arSessionOrigin = GetComponent<ARSessionOrigin>();
        arSessionOrigin = GetComponent<XROrigin>();
        arPointCloudVis = arSessionOrigin.TrackablesParent.GetComponentInChildren<ARPointCloud>();
        // get the point cloud from the point cloud manager
        // pointCloudManager = GetComponent<ARPointCloudManager>();
        // get a list of the point clouds
        pointCloudManager = GetComponent<ARPointCloudManager>();
        pointCloudManager.pointCloudsChanged += PointCloudManager_pointCloudsChanged;
    }
    void Update()
    {
        arPointCloudVis = arSessionOrigin.TrackablesParent.GetComponentInChildren<ARPointCloud>();
        if (arPointCloudVis != null)
        {
            featurePoints = new List<Vector3>(arPointCloud.positions);
            uids = new List<ulong>(arPointCloud.identifiers);
            confs = new List<float>(arPointCloud.confidenceValues);
            float[] pos = new float[3];
            ulong uid = uids[0];
            pos[0] = featurePoints[0].x;
            pos[1] = featurePoints[0].y;
            pos[2] = featurePoints[0].z;
            float conf = confs[0];
            // SavePointCloud.SavePointCloudData(pos);
            totalNumber = featurePoints.Count;
            // Debug.Log(featurePoints[0].x + " " + featurePoints[0].y + " " + featurePoints[0].z);
            // Debug.Log(totalNumber);
            // Debug.Log(arPointCloud);
            Debug.Log(uid + " " + pos[0] + " " + pos[1] + " " + pos[2] + " " + conf);            
        }
    }

    public void SavePointCloudFunc()
    {
        // get a list of the point clouds
        // List<ARPointCloud> pointClouds = pointCloudManager.trackables.ToList();
        // get the first point cloud
        // arPointCloud = pointClouds[0];</ARPointCloud
        // get the number of points in the point cloud
        // totalNumber = arPointCloud.positions.Length;
        // if (arPointCloud != null)
        // {
        //     // arPointCloud = arSessionOrigin.trackablesParent.GetComponentInChildren<ARPointCloud>();
        //     Debug.Log("Save button pressed");
        //     featurePoints = new List<Vector3>(arPointCloud.positions);
        //     uids = new List<ulong>(arPointCloud.identifiers);
        //     confs = new List<float>(arPointCloud.confidenceValues);
        //     float[] pos = new float[3];
        //     Debug.Log("We got here.");
        //     // for loop to interate through the list of feature points and save them
        //     for (int i = 0; i < featurePoints.Count; i++)
        //     {
        //         SavePointCloud.SavePointCloudData(featurePoints, uids, confs);
        //     }
        //     // ulong uid = uids[0];
        //     // pos[0] = featurePoints[0].x;
        //     // pos[1] = featurePoints[0].y;
        //     // pos[2] = featurePoints[0].z;
        //     // float conf = confs[0];
        //     // SavePointCloud.SavePointCloudData();
        //     Debug.Log("We finished.");
        //     // for loop to interate through the list of feature points and save them
        // }
        SavePointCloud.SavePointCloudData(addedPoints);
    }

    private void PointCloudManager_pointCloudsChanged(ARPointCloudChangedEventArgs obj)
    {
        List<ARPoint> addedPoints = new List<ARPoint>();
        foreach (var pointCloud in obj.added)
        {
            foreach (var pos in pointCloud.positions)
            {
                ARPoint newPoint = new ARPoint(pos);
                addedPoints.Add(newPoint);
                Debug.Log(newPoint.x + " " + newPoint.y + " " + newPoint.z);
            }
        }
        List<ARPoint> updatedPoints = new List<ARPoint>();
        foreach (var pointCloud in obj.updated)
        {
            foreach (var pos in pointCloud.positions)
            {
                ARPoint newPoint = new ARPoint(pos);
                updatedPoints.Add(newPoint);
            }
        }
    }

    public class ARPoint
    {
        public float x;
        public float y;
        public float z;
        public ARPoint(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }
}
