using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoomMin = 30;
    private float zoomMax = 90;

    void Start()
    {
        SwipeDetection.ZoomEvent += OnZoom;
    }

    private void OnZoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomMin, zoomMax);
    }

    void Update()
    {

    }
}
