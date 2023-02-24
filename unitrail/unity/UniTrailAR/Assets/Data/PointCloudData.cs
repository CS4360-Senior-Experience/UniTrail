using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointCloudData
{
    public ulong pid;
    public float x;
    public float y;
    public float z;
    public float confidence;

    public PointCloudData(ulong id, float[] pos, float conf)
    {
        pid = id;
        x = pos[0];
        y = pos[1];
        z = pos[2];
        confidence = conf;
    }
}
