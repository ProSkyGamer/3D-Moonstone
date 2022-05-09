using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    private Vector3 coord;
    private Vector3 dir;
    private GameObject swipe;

    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        swipe = GameObject.Find("SwipeDetection");
    }

    void Update()
    {
        if (swipe.activeSelf)
        {
            if (coord != transform.position && coord != Vector3.zero)
            {
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.x > 55)
            {
                coord = transform.position;
                coord.x = 55;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.x < 15)
            {
                coord = transform.position;
                coord.x = 15;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.z > 200)
            {
                coord = transform.position;
                coord.z = 200;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.z < 15)
            {
                coord = transform.position;
                coord.z = 15;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
        }
    }

    private void OnSwipe(Vector3 direction)
    {
        direction.z = direction.y;
        dir = direction * Camera.main.orthographicSize;
        Move(dir);
    }

    private void Move(Vector3 dir)
    {
        coord = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);
        coord.x *= 0.55f;
        coord.z *= 0.55f;

    }

}
