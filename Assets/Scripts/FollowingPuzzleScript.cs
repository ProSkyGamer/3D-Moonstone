using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowingPuzzleScript : MonoBehaviour
{
    private int stage;
    private int curr_show;
    private bool need_show;
    private int[] followingplates;
    private float timer;

    [SerializeField] private GameObject ShowingPlate1;
    [SerializeField] private GameObject ShowingPlate2;
    [SerializeField] private GameObject ShowingPlate3;
    [SerializeField] private GameObject ShowingPlate4;
    [SerializeField] private GameObject ShowingPlate5;
    [SerializeField] private GameObject ShowingPlate6;
    //Показ нужных плиток

    public void StartGame()
    {
        for (int i = 1; i <= 6; i++)
        {
            followingplates[i] = PlayerPrefs.GetInt("followingplate");
        }
        ShowPlates();
    }
    public void ShowPlates()//Показ плит
    {
        stage = PlayerPrefs.GetInt("following_puzzle_stage");
        curr_show = 1;
        need_show = true;
    }

    private void Update()
    {
        if (need_show)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (curr_show == 1)
                {
                    ShowingPlate1.GetComponent<RawImage>().color = new Color(0, 0, 0);
                    curr_show++;
                    timer = 1f;
                }
                else if (curr_show == 2)
                {
                    curr_show++;
                    timer = 1f;
                }
                else if (curr_show == 3)
                {
                    curr_show++;
                    timer = 1f;
                }
                else if (curr_show == 4)
                {
                    curr_show++;
                    timer = 1f;
                }
                else if (curr_show == 5)
                {
                    curr_show++;
                    timer = 1f;
                }
                else if (curr_show == 6)
                {
                    curr_show++;
                    timer = 1f;
                }
            }
        }
    }
}
