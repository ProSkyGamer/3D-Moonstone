using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoomMin = 3;
    private float zoomMax = 10;

    void Start()
    {
        SwipeDetection.ZoomEvent += OnZoom;
    }

    private void OnZoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
    }
}
