using UnityEngine;
using System;

public class broadcastCanvasScale : MonoBehaviour
{
    void Start()
    {
        onMainCanvasEnabled?.Invoke(GetComponent<Canvas>().scaleFactor);
    }

    public static Action<float> onMainCanvasEnabled;
}
