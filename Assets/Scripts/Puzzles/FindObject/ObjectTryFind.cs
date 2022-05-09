using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTryFind : MonoBehaviour, IPointerClickHandler
{
    public bool is_this;
    private FindObjectScript script_controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(script_controller==null)
            script_controller = gameObject.GetComponentInParent<FindObjectScript>();
        if (PlayerPrefs.GetInt("find_object_wait") == 0)
        {
            print("tryed");
            if (is_this)
            {
                GameObject controller = GameObject.Find("Interface Main");
                controller.GetComponent<StartGame>().AfterGameFindObject();
                print("worked");
            }
            else
            {
                print("not this");
                script_controller.NotClick();
            }
        }
        else
        {
            print("wait more");
            script_controller.wait.SetActive(true);
        }
        print("wrong with prefs");
    }
}
