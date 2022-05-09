using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomDetection : MonoBehaviour
{
    public static event OnZoomInPuzzle ZoomEventInPuzzle;
    public delegate void OnZoomInPuzzle(float increment);

    void Update()
    {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    ZoomEventInPuzzle(1);
                else
                ZoomEventInPuzzle(-1);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroLastPose = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOneLastPose = touchOne.position - touchOne.deltaPosition;

                float distTouch = (touchZeroLastPose - touchOneLastPose).magnitude;
                float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

                float difference = currentDistTouch - distTouch;

            ZoomEventInPuzzle(difference);
            }
    }
}
