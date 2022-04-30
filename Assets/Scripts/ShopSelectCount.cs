using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelectCount : MonoBehaviour
{
    [SerializeField] private GameObject curr_item_count;
    [SerializeField] private GameObject curr_item_price;
    private int price_coins;
    public void onStart()
    {
        price_coins = System.Convert.ToInt32(curr_item_price.GetComponent<Text>().text);
        gameObject.GetComponent<Slider>().value = 1;
    }
    public void ChangeValue()
    {
        gameObject.GetComponent<Slider>().value = Mathf.Round(gameObject.GetComponent<Slider>().value);
        if(System.Convert.ToInt32(curr_item_count.GetComponent<Text>().text)!= gameObject.GetComponent<Slider>().value)
        {
            curr_item_count.GetComponent<Text>().text = gameObject.GetComponent<Slider>().value.ToString();
            curr_item_price.GetComponent<Text>().text = (gameObject.GetComponent<Slider>().value * price_coins).ToString();
        }
    }
}
