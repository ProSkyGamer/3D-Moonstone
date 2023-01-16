using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticMovement : MonoBehaviour
{
    [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public bool inpuzzle;
    public bool indialog;
    private Vector3 moved;

    [SerializeField] public float _moveSpeed;
    private int in_game_border_z;


    public void Start()
    {
        in_game_border_z = PlayerPrefs.GetInt("game_border_z");
    }
    private void FixedUpdate()
    {
        if (_joystick.Horizontal !=0 || _joystick.Vertical!=0)
        {
            moved = new Vector3(transform.position.x + _joystick.Horizontal * _moveSpeed, transform.position.y, transform.position.z + _joystick.Vertical * _moveSpeed);
        }
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
                if (moved.z > in_game_border_z)
                {
                    moved.z = in_game_border_z;
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
    public void UpdateBorder(int border_z)
    {
        PlayerPrefs.SetInt("game_border_z", border_z);
        in_game_border_z = PlayerPrefs.GetInt("game_border_z");
    }//макс 200

    public void SetNewPosition(int x,int z)
    {
        moved = new Vector3(x, transform.position.y, z);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, moved.x, Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, moved.z, Time.deltaTime));
    }

    public void SetPositionFindSibling()
    {
        Camera.main.GetComponent<JoysticMovement>().SetNewPosition(29, 60);
    }

    public void SetPositionFollowingPlates()
    {
        Camera.main.GetComponent<JoysticMovement>().SetNewPosition(18, 73);
    }

    public void SetPositionPlates()
    {
        Camera.main.GetComponent<JoysticMovement>().SetNewPosition(28, 65);
    }

    public void SetPositionFindObject()
    {
        Camera.main.GetComponent<JoysticMovement>().SetNewPosition(20, 180);
    }

}
