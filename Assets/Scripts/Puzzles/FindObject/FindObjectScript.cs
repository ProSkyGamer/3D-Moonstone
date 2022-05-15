using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindObjectScript : MonoBehaviour
{
    [Range(0, 10)] private int time_delay = 3;
    [SerializeField] private GameObject timer_wait;
    [SerializeField] public GameObject wait;
    [SerializeField] private GameObject not_right;
    [SerializeField] private GameObject _text_riddle;
    [SerializeField] private GameObject inputField;

    public GameObject Audio_Use_Add_Time;
    public GameObject Audio_Use_Solve_Item;
    public GameObject Audio_Wrong_Object;

    private float timer;
    private float seconds;
    private int obj_to_find;
    private int n_riddle;
    [SerializeField] private GameObject[] all_objects;
    [SerializeField] private string[] all_riddles;
    [SerializeField] private string[] all_answers;

    [SerializeField] private GameObject int_text_solve_puzzle;
    [SerializeField] private GameObject int_text_add_time_weak;
    [SerializeField] private GameObject int_text_add_time_middle;
    [SerializeField] private GameObject int_text_add_time_high;

    private StartGame controller;


    private void Start()
    {
        controller = gameObject.GetComponentInParent<StartGame>();
    }
    public void onStart()
    {
        UpdateMagicItemQuantity();
        _text_riddle.SetActive(true);
        inputField.GetComponent<InputField>().text = "";
        inputField.SetActive(true);
        obj_to_find = Random.Range(0, all_objects.Length);
        n_riddle = Random.Range(0, all_riddles.Length);
        PlayerPrefs.SetInt("find_object_wait", 0);
        all_objects[obj_to_find].GetComponent<ClickEvent>().is_this = true;
        _text_riddle.GetComponent<Text>().text = all_riddles[n_riddle];
        timer_wait.GetComponent<Text>().text = "Можно искать предмет";
        Audio_Use_Add_Time.SetActive(false);
        Audio_Use_Solve_Item.SetActive(false);
        Audio_Wrong_Object.SetActive(false);

    }

    private void Update()
    {
        if (seconds != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= seconds - 1)
            {
                seconds -= 1;
                timer_wait.GetComponent<Text>().text = "Следующая попытка найти через " + seconds.ToString();
                if (seconds == 0)
                {
                    PlayerPrefs.SetInt("find_object_wait", 0);
                    timer_wait.GetComponent<Text>().text = "Можно искать предмет";
                }
            }
        }
    }

    public void NotClick()
    {
        PlayerPrefs.SetInt("find_object_wait", time_delay);
        seconds = time_delay;
        timer = time_delay;
        timer_wait.GetComponent<Text>().text = "Следующая попытка найти через " + seconds.ToString();
        Audio_Wrong_Object.SetActive(false);
        Audio_Wrong_Object.SetActive(true);
    }

    public void onChangeValue()
    {
        if(inputField.GetComponent<InputField>().text.Replace(" ","").ToLower()==all_answers[n_riddle])
        {
            all_objects[obj_to_find].GetComponent<Outline>().enabled = true;
            inputField.SetActive(false);
            _text_riddle.SetActive(false);
        }
        else
        {
            not_right.GetComponent<TextDissapear>().OnceMore();
        }
    }

    public void UsedSolveItem()
    {
        controller.AfterGameFindObject();
        PlayerPrefs.SetInt("magic_item_solve_2d_puzzle", PlayerPrefs.GetInt("magic_item_solve_2d_puzzle") - 1);
        UpdateMagicItemQuantity();
    }

    public void UpdateMagicItemQuantity()
    {
        int_text_solve_puzzle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_solve_2d_puzzle").ToString();
        int_text_add_time_weak.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_weak").ToString();
        int_text_add_time_middle.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_middle").ToString();
        int_text_add_time_high.GetComponent<Text>().text = PlayerPrefs.GetInt("magic_item_add_time_high").ToString();
    }

    public void TurnOffAllLightning()
    {
        foreach(GameObject g in all_objects)
        {
            g.GetComponent<Outline>().enabled = false;
        }
    }
}
