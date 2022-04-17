using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTimer : MonoBehaviour
{
    public int start_minutes;
    public string game_name;
    private int minutes;
    private float seconds;

    void Start()
    {
        minutes = start_minutes;
        gameObject.GetComponent<Text>().text = (minutes - 1).ToString() + ":60"; 
    }

    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0.2)
            {
                minutes -= 1;
                if (minutes == -1)
                {
                    GameObject controller = GameObject.Find("Interface Main");
                    if (game_name == "plates")
                        controller.GetComponent<StartGame>().LoseGamePlates();
                    else if (game_name == "findsibling")
                        controller.GetComponent<StartGame>().LoseGameFindSibling();
                    else if (game_name == "followingplates")
                        controller.GetComponent<StartGame>().LoseGameFollowingPlates();
                }
                seconds = 60;
            }
            gameObject.GetComponent<Text>().text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();
        }

    }
    public void OnStart()
    {
        minutes = start_minutes;
        seconds = 0;
        gameObject.GetComponent<Text>().text = (minutes - 1).ToString() + ":60";
    }
}
