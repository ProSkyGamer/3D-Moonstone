using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowingPuzzleScript : MonoBehaviour
{
    private GameObject controller;
    private int stage;
    private int curr_show;
    private bool need_show;
    private bool after_show;
    private bool need_off;
    private int[] followingplates = new int[7];
    private float timer;

    [SerializeField] private GameObject ShowingPlate1;
    [SerializeField] private GameObject ShowingPlate2;
    [SerializeField] private GameObject ShowingPlate3;
    [SerializeField] private GameObject ShowingPlate4;
    [SerializeField] private GameObject ShowingPlate5;
    [SerializeField] private GameObject ShowingPlate6;

    [SerializeField] private Color Plate1;
    [SerializeField] private Color Plate2;
    [SerializeField] private Color Plate3;
    [SerializeField] private Color Plate4;
    [SerializeField] private Color Plate5;
    [SerializeField] private Color Plate6;
    [SerializeField] private Color PlateNull;

    [SerializeField] private GameObject int_text_solve_puzzle;
    [SerializeField] private GameObject int_text_add_time_weak;
    [SerializeField] private GameObject int_text_add_time_middle;
    [SerializeField] private GameObject int_text_add_time_high;
    //����� ������ ������

    public void StartGame()
    {
        UpdateMagicItemQuantity();
        controller = GameObject.Find("Interface Main");
        for (int i = 1; i <= 9; i++)
        {
            followingplates[i] = PlayerPrefs.GetInt("followingplate" + i);
        }
        ShowPlates();
    }
    public void ShowPlates()//����� ����
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
                if (!need_off)
                {
                    if (followingplates[curr_show] == 1)
                    {
                        ShowingPlate1.GetComponent<RawImage>().color = Plate1;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    else if (followingplates[curr_show] == 2)
                    {
                        ShowingPlate2.GetComponent<RawImage>().color = Plate2;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    else if (followingplates[curr_show] == 3)
                    {
                        ShowingPlate3.GetComponent<RawImage>().color = Plate3;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    else if (followingplates[curr_show] == 4)
                    {
                        ShowingPlate4.GetComponent<RawImage>().color = Plate4;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    else if (followingplates[curr_show] == 5)
                    {
                        ShowingPlate5.GetComponent<RawImage>().color = Plate5;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    else if (followingplates[curr_show] == 6)
                    {
                        ShowingPlate6.GetComponent<RawImage>().color = Plate6;
                        curr_show++;
                        timer = 0.5f;
                        need_off = true;
                    }
                    
                }
                else
                {
                    if (curr_show > stage)
                    {
                        need_show = false;
                    }
                    need_off = false;
                    ClearColor();
                    timer = 1f;
                }
            }
        }
    }

    private void ClearColor()
    {
        ShowingPlate1.GetComponent<RawImage>().color = PlateNull;
        ShowingPlate2.GetComponent<RawImage>().color = PlateNull;
        ShowingPlate3.GetComponent<RawImage>().color = PlateNull;
        ShowingPlate4.GetComponent<RawImage>().color = PlateNull;
        ShowingPlate5.GetComponent<RawImage>().color = PlateNull;
        ShowingPlate6.GetComponent<RawImage>().color = PlateNull;
    }

    public void UsedSolveItem()
    {
        controller.GetComponent<StartGame>().AfterGameFollowingPlates();
        PlayerPrefs.SetInt("magic_item_solve_2d_puzzle", PlayerPrefs.GetInt("magic_item_solve_2d_puzzle") - 1);
        UpdateMagicItemQuantity();
    }

    public void UpdateMagicItemQuantity()
    {
        int_text_solve_puzzle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_solve_2d_puzzle").ToString();
        int_text_add_time_weak.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_weak").ToString();
        int_text_add_time_middle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_middle").ToString();
        int_text_add_time_high.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_high").ToString();
    }
}
