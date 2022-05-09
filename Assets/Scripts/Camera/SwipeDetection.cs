using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector3 direction);
    public static event OnZoomInput ZoomEvent;
    public delegate void OnZoomInput(float increment);

    private Vector3 tapPosition;
    private Vector3 swipeDelta;

    private bool isSwiping;

    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            /*if (!isSwiping)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isSwiping = true;
                    tapPosition = Input.mousePosition;
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if (tapPosition != Input.mousePosition)
                    {
                        swipeDelta = tapPosition - Input.mousePosition;
                        print(swipeDelta);
                        SwipeEvent(swipeDelta);
                        tapPosition = Input.mousePosition;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }*/

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    ZoomEvent(1);
                else
                    ZoomEvent(-1);
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

                ZoomEvent(difference);
            }
        }
    }

    private void ResetSwipe()
    {
        isSwiping = false;

        tapPosition = Vector3.zero;
        swipeDelta = Vector3.zero;
    }
}
