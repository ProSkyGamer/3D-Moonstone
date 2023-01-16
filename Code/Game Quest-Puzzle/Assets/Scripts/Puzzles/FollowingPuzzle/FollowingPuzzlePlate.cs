using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPuzzlePlate : MonoBehaviour
{
    private int number;
    private GameObject FollowingScript;


    private void Start()
    {
        FollowingScript = GameObject.Find("Following Puzzle Script");
    }
    public void onClickFollowingPlate()
    {
        number =System.Convert.ToInt32(gameObject.name);
        if(number==PlayerPrefs.GetInt("followingplate"+PlayerPrefs.GetInt("following_click_stage")))//Сравнение нужной плиты с текущей нажатой
        {
            PlayerPrefs.SetInt("following_click_stage", PlayerPrefs.GetInt("following_click_stage") + 1);
            if(PlayerPrefs.GetInt("following_click_stage")>PlayerPrefs.GetInt("following_puzzle_stage"))//Проверка на конец текущей стандии
            {
                PlayerPrefs.SetInt("following_click_stage", 1);
                PlayerPrefs.SetInt("following_puzzle_stage", PlayerPrefs.GetInt("following_puzzle_stage")+ 1);
                if(PlayerPrefs.GetInt("following_puzzle_stage")==10)//Проверка на конец игры
                {
                    GameObject controller = GameObject.Find("Interface Main");
                    controller.GetComponent<StartGame>().AfterGameFollowingPlates();
                }
                else
                    FollowingScript.GetComponent<FollowingPuzzleScript>().ShowPlates();
            }
        }
        else
        {   
            FollowingScript.GetComponent<FollowingPuzzleScript>().WrongPlate();
            ResetStage();
            FollowingScript.GetComponent<FollowingPuzzleScript>().ShowPlates();
            
        }
    }

    private void ResetStage()
    {
        PlayerPrefs.SetInt("following_puzzle_stage", 1);
        PlayerPrefs.SetInt("following_click_stage", 1);
    }
}
