using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopQuantityChoose : MonoBehaviour
{
    [SerializeField] private GameObject WarningInterface;
    [SerializeField] private GameObject WarningInterface_count;
    [SerializeField] private GameObject _item_name;
    [SerializeField] private GameObject curr_item_count;
    [SerializeField] private GameObject curr_item_price;
    public void CurrCountBuyItem()
    {
        WarningInterface.SetActive(true);
        WarningInterface_count.GetComponent<Text>().text = "¬ы уверены, что хотите приобрести " + curr_item_count.GetComponent<Text>().text +
            " " + _item_name.GetComponent<Text>().text + " по цене " + curr_item_price.GetComponent<Text>().text + "?";
    }
}
