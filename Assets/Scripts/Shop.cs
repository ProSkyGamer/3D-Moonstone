using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _count_coins;
    [SerializeField] private GameObject _count_magic_item_add_time_weak;
    [SerializeField] private GameObject _count_magic_item_add_time_middle;
    [SerializeField] private GameObject _count_magic_item_add_time_high;
    [SerializeField] private GameObject _count_magic_item_solve_2d_puzzle;

    public void UpdateCount()
    {
        _count_coins.GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
        _count_magic_item_add_time_weak.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_weak").ToString();
        _count_magic_item_add_time_middle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_middle").ToString();
        _count_magic_item_add_time_high.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_high").ToString();
        _count_magic_item_solve_2d_puzzle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_solve_2d_puzzle").ToString();
    }
}
