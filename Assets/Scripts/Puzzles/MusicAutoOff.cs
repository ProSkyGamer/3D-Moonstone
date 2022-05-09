using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAutoOff : MonoBehaviour
{
    private float time_audio;
    private void Start()
    {
        time_audio = gameObject.GetComponent<AudioSource>().time;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            print("it work");
            if (time_audio > 0)
            {
                time_audio -= Time.deltaTime;
            }
            else
            {
                time_audio = gameObject.GetComponent<AudioSource>().time;
                //gameObject.SetActive(false);
            }
        }
    }

    public void NewStart()
    {
        gameObject.SetActive(false);
        time_audio = gameObject.GetComponent<AudioSource>().time;
        gameObject.SetActive(true);
    }
}
