using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopChoseBuy : MonoBehaviour
{
    private int coins;
    private int curr_price;
    [SerializeField] private GameObject BuyingInterface;
    [SerializeField] private string item_name;
    [SerializeField] private GameObject _item_name;
    [SerializeField] private string ingame_item_name;
    [SerializeField] private GameObject _inGame_item_name;
    [SerializeField] private GameObject max_item_count;
    [SerializeField] private GameObject curr_item_price;
    [SerializeField] private GameObject slider_curr_count;
    private void Start()
    {
        curr_price = System.Convert.ToInt32(gameObject.GetComponentInChildren<Text>().text);
    }
    public void OnTryBuyItem()
    {
        coins = PlayerPrefs.GetInt("coins");
        if (coins >= curr_price)
        {
            BuyingInterface.SetActive(true);
            _item_name.GetComponent<Text>().text = item_name;
            curr_item_price.GetComponent<Text>().text = curr_price.ToString();
            max_item_count.GetComponent<Text>().text = Mathf.Floor(coins / curr_price).ToString();
            slider_curr_count.GetComponent<Slider>().maxValue = Mathf.Floor(coins / curr_price);
            slider_curr_count.GetComponent<ShopSelectCount>().onStart();
            _inGame_item_name.GetComponent<Text>().text = ingame_item_name;
        }
        else
        {

        }
    }
}
