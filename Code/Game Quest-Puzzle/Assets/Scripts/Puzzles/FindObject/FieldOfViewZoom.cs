using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewZoom : MonoBehaviour
{
    private float zoomMin = 30;
    private float zoomMax = 60;

    void Start()
    {
        ZoomDetection.ZoomEventInPuzzle += OnZoomInPuzzle;
    }

    private void OnZoomInPuzzle(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomMin, zoomMax);
    }
}
