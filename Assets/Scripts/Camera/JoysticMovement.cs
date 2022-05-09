using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticMovement : MonoBehaviour
{
    [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public bool inpuzzle;
    private Vector3 moved;

    [SerializeField] public float _moveSpeed;


    private void FixedUpdate()
    {
        if (_joystick.enabled)
        {
            moved = new Vector3(transform.position.x + _joystick.Horizontal * _moveSpeed, transform.position.y, transform.position.z + _joystick.Vertical * _moveSpeed);
            if (!inpuzzle)
            {
                if (moved.x > 55)
                {
                    moved.x = 55;
                }
                if (moved.x < 15)
                {
                    moved.x = 15;
                }
                if (moved.z > 200)
                {
                    moved.z = 200;
                }
                if (moved.z < 15)
                {
                    moved.z = 15;
                }
            }
            else
            {
                if (moved.x > 40)
                {
                    moved.x = 40;
                }
                if (moved.x < 28)
                {
                    moved.x = 28;
                }
                if (moved.z > 208)
                {
                    moved.z = 208;
                }
                if (moved.z < 196)
                {
                    moved.z = 196;
                }
            }

            //28 - 40    x
            //-3 y
            //196-208
            if (moved != transform.position)
            {
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, moved.x, Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, moved.z, Time.deltaTime));
            }
        }
    }
}
