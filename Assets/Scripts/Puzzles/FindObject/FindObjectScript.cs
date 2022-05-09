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




    public void onStart()
    {
        obj_to_find = Random.Range(0, all_objects.Length);
        n_riddle = Random.Range(0, all_riddles.Length);
        all_objects[obj_to_find].GetComponent<ClickEvent>().is_this = true;
        _text_riddle.GetComponent<Text>().text = all_riddles[n_riddle];
        timer_wait.GetComponent<Text>().text = "Можно искать предмет";
        print(obj_to_find);
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
}
