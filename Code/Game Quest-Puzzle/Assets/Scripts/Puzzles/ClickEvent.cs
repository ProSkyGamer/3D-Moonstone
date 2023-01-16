using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public GameObject MenuPuzzleInterface;
    public GameObject SwipesDetection;
    public GameObject IterfaceMain;
    public bool is_this;
    public bool inGame;
    private StartGame start;
    private FindObjectScript script_controller;

    private void Start()
    {
        start=  GameObject.Find("Interface Main").GetComponent<StartGame>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!inGame)
        {
            MenuPuzzleInterface.SetActive(true);
            SwipesDetection.SetActive(false);
            IterfaceMain.SetActive(false);
            start.HideRiddles();

        }
        else
        {
            if (script_controller == null)
                script_controller = GameObject.Find("FindObjectScript").GetComponent<FindObjectScript>();
            if (PlayerPrefs.GetInt("find_object_wait") == 0)
            {
                if (is_this)
                {
                    gameObject.GetComponent<Outline>().enabled = false;
                    GameObject controller = GameObject.Find("Interface Main");
                    controller.GetComponent<StartGame>().AfterGameFindObject();
                }
                else
                {
                    script_controller.NotClick();
                }
            }
            else
            {
                script_controller.wait.SetActive(true);
            }
        }
    }

}
