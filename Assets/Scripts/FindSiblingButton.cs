using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSiblingButton : MonoBehaviour
{
    public string type;
    private GameObject controller;
    private bool need;
    private GameObject sibling;
    private float timer=1f;


    private void Start()
    {
        controller = GameObject.Find("Interface Main");
        PlayerPrefs.SetString("sibling", "x");
        PlayerPrefs.SetInt("sibling_pairs", 0);
    }
    public void OnClickSibling()
    {
        if (!need)
        {
            if (PlayerPrefs.GetString("sibling") == "x")
            {
                PlayerPrefs.SetString("sibling", type);
                PlayerPrefs.SetString("sibling_name", gameObject.name);
                gameObject.transform.position = new Vector3(transform.position.x - 2000, transform.position.y, transform.position.z);
            }
            else
            {
                sibling = GameObject.Find(PlayerPrefs.GetString("sibling_name"));

                if (PlayerPrefs.GetString("sibling") == type)
                {
                    sibling.transform.position = new Vector3(sibling.transform.position.x + 2000, sibling.transform.position.y, sibling.transform.position.z);
                    gameObject.SetActive(false);
                    sibling.SetActive(false);
                    PlayerPrefs.SetInt("sibling_pairs", PlayerPrefs.GetInt("sibling_pairs") + 1);
                    PlayerPrefs.SetString("sibling", "x");
                    PlayerPrefs.SetString("sibling_name", "");
                    if (PlayerPrefs.GetInt("sibling_pairs") == 12)
                    {
                        controller.GetComponent<StartGame>().AfterGameFindSibling();
                    }
                }
                else
                {
                    gameObject.transform.position = new Vector3(transform.position.x - 2000, transform.position.y, transform.position.z);
                    need = true;
                    PlayerPrefs.SetString("sibling", "x");
                    PlayerPrefs.SetString("sibling_name", "");
                }
            }
        }
        
    }

    private void Update()
    {
        if(need)
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                timer = 1f;
                need = false;

                gameObject.transform.position = new Vector3(transform.position.x + 2000, transform.position.y, transform.position.z);
                sibling.transform.position = new Vector3(sibling.transform.position.x + 2000, sibling.transform.position.y, sibling.transform.position.z);
            }
        }
    }
}
