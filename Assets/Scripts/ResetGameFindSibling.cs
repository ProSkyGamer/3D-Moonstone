using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameFindSibling : MonoBehaviour
{

    private int[] list = new int[13];
    private GameObject controller;
    public Texture[] images = new Texture[13];
    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;
    public GameObject plate5;

    public GameObject plate6;
    public GameObject plate7;
    public GameObject plate8;
    public GameObject plate9;
    public GameObject plate10;

    public GameObject plate11;
    public GameObject plate12;
    public GameObject plate14;
    public GameObject plate15;

    public GameObject plate16;
    public GameObject plate17;
    public GameObject plate18;
    public GameObject plate19;
    public GameObject plate20;

    public GameObject plate21;
    public GameObject plate22;
    public GameObject plate23;
    public GameObject plate24;
    public GameObject plate25;

    [SerializeField] private GameObject int_text_solve_puzzle;
    [SerializeField] private GameObject int_text_add_time_weak;
    [SerializeField] private GameObject int_text_add_time_middle;
    [SerializeField] private GameObject int_text_add_time_high;

    public GameObject[] plates_massiv = new GameObject[26];


    private void Start()
    {
        plates_massiv[1] = plate1;
        plates_massiv[2] = plate2;
        plates_massiv[3] = plate3;
        plates_massiv[4] = plate4;
        plates_massiv[5] = plate5;

        plates_massiv[6] = plate6;
        plates_massiv[7] = plate7;
        plates_massiv[8] = plate8;
        plates_massiv[9] = plate9;
        plates_massiv[10] = plate10;

        plates_massiv[11] = plate11;
        plates_massiv[12] = plate12;
        plates_massiv[14] = plate14;
        plates_massiv[15] = plate15;

        plates_massiv[16] = plate16;
        plates_massiv[17] = plate17;
        plates_massiv[18] = plate18;
        plates_massiv[19] = plate19;
        plates_massiv[20] = plate20;

        plates_massiv[21] = plate21;
        plates_massiv[22] = plate22;
        plates_massiv[23] = plate23;
        plates_massiv[24] = plate24;
        plates_massiv[25] = plate25;

        controller = GameObject.Find("Interface Main");
    }
    public void ResetFindSibling()
    {
        for (int i = 1; i <= 25; i++)
        {
            if (i != 13)
            {
                plates_massiv[i].SetActive(true);
            }
        }
    }

    public void onStart()
    {
        Start();
        UpdateMagicItemQuantity();
        for (int i = 0; i <= 12; i++)
        {
            list[i] = 0;
        }
        ResetFindSibling();
        for (int i = 1; i <= 25; i++)
        {
            if (i != 13)
            {
                bool need = true;
                while (need)
                {
                    int number = Random.Range(1, 13);
                    if (list[number] < 2)
                    {
                        list[number] += 1;
                        plates_massiv[i].transform.parent.GetComponent<RawImage>().texture = images[number];
                        plates_massiv[i].GetComponent<FindSiblingButton>().type = number.ToString();
                        need = false;
                    }
                }
            }
        }
    }

    public void UsedSolveItem()
    {
        controller.GetComponent<StartGame>().AfterGameFindSibling();
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
