using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTimer : MonoBehaviour
{
    private float minutes;
    private float seconds;
    private int lives;
    public Text livesTimer;
    public GameObject livesTimer_obj;
    private GameObject controller;
    void Start()
    {
       if(PlayerPrefs.GetString("livesTimer_isset")!="yes")
        {
            PlayerPrefs.SetFloat("timer_lives_minutes", 4);
            PlayerPrefs.SetFloat("timer_lives_seconds", 60);
            PlayerPrefs.SetString("livesTimer_isset", "yes");
        }
        minutes = PlayerPrefs.GetFloat("timer_lives_minutes");
        seconds = PlayerPrefs.GetFloat("timer_lives_seconds");
        livesTimer.text = minutes.ToString() + ":" + seconds.ToString();
        controller = GameObject.Find("Interface Main");
    }

    void Update()
    {
        lives = PlayerPrefs.GetInt("lives");
        if (lives < 5)
        {
            if(livesTimer_obj.activeSelf==false)
            {
                livesTimer_obj.SetActive(true);
                livesTimer.text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();
            }
            seconds -= Time.deltaTime;
            if (PlayerPrefs.GetFloat("timer_lives_seconds") - 1 > seconds)
            {
                if (seconds <= 0.2)
                {
                    PlayerPrefs.SetFloat("timer_lives_minutes", PlayerPrefs.GetFloat("timer_lives_minutes") - 1f);
                    if (PlayerPrefs.GetFloat("timer_lives_minutes") == -1)
                    {
                        PlayerPrefs.SetFloat("timer_lives_minutes", 4);
                        minutes = 5;
                        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
                        controller.GetComponent<StartGame>().UpadteInfo();
                    }
                    PlayerPrefs.SetFloat("timer_lives_seconds", 60);
                    minutes -= 1;
                    seconds = 60;
                }
                else
                    PlayerPrefs.SetFloat("timer_lives_seconds", Mathf.Round(seconds));
                if (seconds <= 9.5 && seconds >= 0.2)
                    livesTimer.text = minutes.ToString() + ":0" + Mathf.Round(seconds).ToString();
                else
                    livesTimer.text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();

            }
        }
        else
        {
            PlayerPrefs.SetFloat("timer_lives_minutes", 4);
            PlayerPrefs.SetFloat("timer_lives_seconds", 60);
            minutes = 4;
            seconds = 60;
            livesTimer_obj.SetActive(false);
            
        }
    }
}
