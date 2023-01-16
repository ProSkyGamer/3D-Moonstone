using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyItem : MonoBehaviour
{
    private int coins;
    private int curr_price;
    [SerializeField] private GameObject _inGame_item_name;
    [SerializeField] private GameObject BuyingInterface;
    [SerializeField] private GameObject WarningInterface;
    [SerializeField] private GameObject curr_item_count;
    [SerializeField] private GameObject curr_item_price;
    public void ConfirmBuyItem()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - System.Convert.ToInt32(curr_item_price.GetComponent<Text>().text));
        PlayerPrefs.SetInt(_inGame_item_name.GetComponent<Text>().text, PlayerPrefs.GetInt(_inGame_item_name.GetComponent<Text>().text) + System.Convert.ToInt32(curr_item_count.GetComponent<Text>().text));
        WarningInterface.SetActive(false);
        BuyingInterface.SetActive(false);
    }
}
