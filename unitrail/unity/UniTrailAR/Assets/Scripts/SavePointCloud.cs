using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;


public static class SavePointCloud
{
    
    // function to save point cloud data to a text file without formatter
    public static void SavePointCloudData(List<PointNumberCount.ARPoint> points)
    {
        string path = Application.persistentDataPath + "/pointCloudData.fun";
        FileStream fs = new FileStream(path, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        if (points == null)
        {
            Debug.LogError("No point cloud data to save!");
            return;
        }
        for (int i = 0; i < points.Count; i++)
        {
            sw.WriteLine(points[i].x + " " + points[i].y + " " + points[i].z);
        }
        sw.Close();
        fs.Close();
    }

    public static PointCloudData LoadPointCloudData()
    {
        string path = Application.persistentDataPath + "/pointCloudData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PointCloudData data = formatter.Deserialize(stream) as PointCloudData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
