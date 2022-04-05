using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSiblingButton : MonoBehaviour
{
    public string type;
    private GameObject controller;


    private void Start()
    {
        controller = GameObject.Find("Interface Main");
        PlayerPrefs.SetString("sibling", "x");
        PlayerPrefs.SetInt("sibling_pairs", 0);
    }
    public void OnClickSibling()
    {
        if(PlayerPrefs.GetString("sibling")=="x")
        {
            PlayerPrefs.SetString("sibling",type);
            PlayerPrefs.SetString("sibling_name", gameObject.name);
            gameObject.transform.position = new Vector3(transform.position.x - 2000,transform.position.y,transform.position.z);
        }
        else
        {
            GameObject sibling = GameObject.Find(PlayerPrefs.GetString("sibling_name"));
            sibling.transform.position = new Vector3(sibling.transform.position.x + 2000, sibling.transform.position.y, sibling.transform.position.z);
            if (PlayerPrefs.GetString("sibling")==type)
            {
                gameObject.SetActive(false);
                sibling.SetActive(false);
                PlayerPrefs.SetInt("sibling_pairs", PlayerPrefs.GetInt("sibling_pairs") + 1);
                PlayerPrefs.SetString("sibling", "x");
                PlayerPrefs.SetString("sibling_name", "");
                if (PlayerPrefs.GetInt("sibling_pairs") == 12)
                {
                    GameObject new_controller = GameObject.Find("FindSibling Script");
                    new_controller.GetComponent<ResetGameFindSibling>().ResetFindSibling();
                    controller.GetComponent<StartGame>().AfterGameFindSibling();
                }
            } 
            else
            { 
                gameObject.SetActive(true);
                PlayerPrefs.SetString("sibling", "x");
                PlayerPrefs.SetString("sibling_name", "");
            }
        }
        
    }
}
