using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvasScale : MonoBehaviour
{
    Canvas canvas;
    [SerializeField] FloatVariable canvasScale;
   
    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        canvasScale.value = canvas.scaleFactor;
    }
}
