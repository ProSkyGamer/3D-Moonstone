using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text coins_int;
    public Text exp_int;
    public Text lives_int;
    public GameObject _interface;
    public GameObject plates_game_interface;
    public GameObject plates_interface;
    public GameObject findsibling_game_interface;
    public GameObject findsibling_interface;

    void Start()
    {
        if (PlayerPrefs.GetInt("max_experience") == 0)
        {
            PlayerPrefs.SetInt("max_experience", 100);
        }
        if(PlayerPrefs.GetString("lives_isset")!="yes")
        {
            PlayerPrefs.SetString("lives_isset", "yes");
            PlayerPrefs.SetInt("lives", 5);
        }
        int lives = PlayerPrefs.GetInt("lives");
        int coins = PlayerPrefs.GetInt("coins");
        int exp = PlayerPrefs.GetInt("experience");
        int max_exp = PlayerPrefs.GetInt("max_experience");

        

        coins_int.text = System.Convert.ToString(coins);
        lives_int.text = System.Convert.ToString(lives);
        exp_int.text = System.Convert.ToString(exp + "/" + max_exp);
        
    }

    public void LivesCountMinus()
    {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
    }

    public void UpadteInfo()
    {   if(PlayerPrefs.GetInt("experience")>=PlayerPrefs.GetInt("max_experience"))
        {
            PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") - PlayerPrefs.GetInt("max_experience"));
            PlayerPrefs.SetInt("max_experience", PlayerPrefs.GetInt("max_experience") + 100);
        }

        int lives = PlayerPrefs.GetInt("lives");
        int coins = PlayerPrefs.GetInt("coins");
        int exp = PlayerPrefs.GetInt("experience");
        int max_exp = PlayerPrefs.GetInt("max_experience");


        coins_int.text = System.Convert.ToString(coins);
        lives_int.text = System.Convert.ToString(lives);
        exp_int.text = System.Convert.ToString(exp + "/" + max_exp);
    }

    public void AfterGamePlates()
    {
        _interface.SetActive(true);
        plates_game_interface.SetActive(false);
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
        PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") + 10);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + Random.Range(10, 20));
        UpadteInfo();
    }

    public void StartGamePlates()
    {
        if(PlayerPrefs.GetInt("lives")>0)
        {
            LivesCountMinus();
            plates_interface.SetActive(false);
            plates_game_interface.SetActive(true);
            plates_game_interface.GetComponentInChildren<PuzzleTimer>().OnStart();
        }
    }

    public void LoseGamePlates()
    {
        _interface.SetActive(true);
        plates_game_interface.SetActive(false);
        UpadteInfo();
    }

    public void StartGameFindSibling()
    {
        if (PlayerPrefs.GetInt("lives") > 0)
        {
            LivesCountMinus();
            findsibling_interface.SetActive(false);
            findsibling_game_interface.SetActive(true);
            PlayerPrefs.SetInt("sibling_pairs", 0);
            PlayerPrefs.SetString("sibling", "x");
            findsibling_game_interface.GetComponentInChildren<PuzzleTimer>().OnStart();
        }
    }
    public void AfterGameFindSibling()
    {
        PlayerPrefs.SetInt("sibling_pairs", 0);
        PlayerPrefs.SetString("sibling", "x");
        _interface.SetActive(true);
        findsibling_game_interface.SetActive(false);
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
        PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") + 10);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + Random.Range(10, 20));
        UpadteInfo();
    }

    public void LoseGameFindSibling()
    {
        _interface.SetActive(true);
        findsibling_game_interface.SetActive(false);
        UpadteInfo();
    }

    public void AddLives()
    {
        PlayerPrefs.SetInt("lives", 5);
        UpadteInfo();
    }
}
