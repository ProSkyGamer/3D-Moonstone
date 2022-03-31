using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    private Vector3 coord;
    private Vector3 dir;

    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void Update()
    {

        if (coord != transform.position && coord != Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
        }
        if (transform.position.x >= 800)
        {
            coord.x = 800;
            transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
        }
        if (transform.position.x <= -10)
        {
            coord.x = 0;
            transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
        }
        if (transform.position.z >= 800)
        {
            coord.z = 800;
            transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
        }
        if (transform.position.z <= -10)
        {
            coord.z = 0;
            transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
        }
    }

    private void OnSwipe(Vector3 direction)
    {
        direction.x = -direction.x;
        direction.z = -direction.y;
        direction.y = transform.position.y;
         dir = direction * Camera.main.fieldOfView;
        Move(dir);
    }

    private void Move(Vector3 dir)
    {
        coord = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + dir.x, speed * Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, transform.position.z + dir.z, speed * Time.deltaTime));
    }

}
