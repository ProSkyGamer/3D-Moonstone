using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingMagicItem : MonoBehaviour
{

    [SerializeField] private string magic_item_name;
    [SerializeField] private GameObject use_item_button;
    [SerializeField] private GameObject warning_using_item;
    [SerializeField] private GameObject _text_not_enough;

    public void TryUseMagicItem()
    {
        if (PlayerPrefs.GetInt("magic_item_" + magic_item_name) > 0)
        {
            warning_using_item.SetActive(true);
            use_item_button.SetActive(true);
        }
        else
        {
            _text_not_enough.SetActive(true);
        }
    }

    public void BeforeTryUseAddTime()
    {
        if (PlayerPrefs.GetInt("magic_item_add_time_weak") > 0 || PlayerPrefs.GetInt("magic_item_add_time_middle") > 0 || PlayerPrefs.GetInt("magic_item_add_time_high") > 0)
        {
            use_item_button.SetActive(true);
        }
        else
        {
            _text_not_enough.SetActive(true);
            _text_not_enough.GetComponent<TextDissapear>().OnceMore();
        }
    }

}
