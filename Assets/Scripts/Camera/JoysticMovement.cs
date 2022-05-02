using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    private Vector3 coord;

    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        coord.y = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (_joystick.enabled)
        {
            if (transform.position.x > 50)
            {
                coord = transform.position;
                coord.x = 50;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.x < 10)
            {
                coord = transform.position;
                coord.x = 10;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.z > 50)
            {
                coord = transform.position;
                coord.z = 50;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }
            if (transform.position.z < 10)
            {
                coord = transform.position;
                coord.z = 10;
                transform.position = Vector3.Lerp(transform.position, coord, Time.deltaTime);
            }

            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        }
    }
}
