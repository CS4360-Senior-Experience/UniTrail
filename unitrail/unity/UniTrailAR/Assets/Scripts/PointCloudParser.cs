using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PointCloudParser : MonoBehaviour
{
    public ARPointCloudManager pointCloudManager;
    private void OnEnable()
    {
        pointCloudManager.pointCloudsChanged += PointCloudManager_pointCloudsChanged;
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