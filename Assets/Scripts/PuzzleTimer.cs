using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTimer : MonoBehaviour
{
    public int start_minutes;
    [Range(0,59)] public int start_seconds;
    public string game_name;
    private int minutes;
    public float seconds;

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
            if(seconds<=9.5 && seconds>=0.2)
                gameObject.GetComponent<Text>().text = minutes.ToString() + ":0" + Mathf.Round(seconds).ToString();
            else
                gameObject.GetComponent<Text>().text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();
        }

    }
    public void OnStart()
    {
        minutes = start_minutes;
        seconds = start_seconds;
        if(start_seconds<10 && start_seconds>0)
            gameObject.GetComponent<Text>().text = minutes.ToString() + ":0"+start_seconds;
        else if(start_seconds==0)
            gameObject.GetComponent<Text>().text = (minutes-1).ToString() + ":60";
        else
            gameObject.GetComponent<Text>().text = minutes.ToString() + ":" + start_seconds;
    }

    public void AddTime(int addedtimeminutes)
    {
        minutes += addedtimeminutes;
        //Минус один предмет
    }
}
