using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPuzzlePlate : MonoBehaviour
{
    private int number;

    [SerializeField] private GameObject FollowingPuzzleScript;

    public void onClickFollowingPlate()
    {
        number =System.Convert.ToInt32(gameObject.name);
        print(number);
        if(number==PlayerPrefs.GetInt("followingplate"+PlayerPrefs.GetInt("following_click_stage")))//��������� ������ ����� � ������� �������
        {
            PlayerPrefs.SetInt("following_click_stage", PlayerPrefs.GetInt("following_click_stage") + 1);
            if(PlayerPrefs.GetInt("following_click_stage")==PlayerPrefs.GetInt("following_puzzle_stage"))//�������� �� ����� ������� �������
            {
                PlayerPrefs.SetInt("following_click_stage", 1);
                PlayerPrefs.SetInt("following_puzzle_stage", PlayerPrefs.GetInt("following_puzzle_stage")+ 1);
                if(PlayerPrefs.GetInt("following_puzzle_stage")==7)//�������� �� ����� ����
                {
                    //GameEnd
                }
                FollowingPuzzleScript.GetComponent<FollowingPuzzleScript>().ShowPlates();
            }
        }
        else
        {
            ResetStage();
        }
    }

    private void ResetStage()
    {
        PlayerPrefs.SetInt("following_puzzle_stage", 1);
        PlayerPrefs.SetInt("following_click_stage", 1);
    }
}
