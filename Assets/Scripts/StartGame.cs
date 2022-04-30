using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text coins_int;
    public Text exp_int;
    public Text lives_int;
    private bool need;
    private string game;
    public GameObject swiping;
    public GameObject _interface;
    public GameObject plates_game_interface;
    public GameObject plates_interface;
    public GameObject plates_rewards;
    private GameObject plates_rewards_magicitem;
    public GameObject findsibling_game_interface;
    public GameObject findsibling_interface;
    public GameObject findsibling_rewards;
    public GameObject followingplates_game_interface;
    public GameObject followingplates_interface;
    public GameObject followingplates_rewards;
    private GameObject followingplates_rewards_magicitem;

    void Start()
    {
        if (PlayerPrefs.GetInt("max_experience") == 0)
        {
            PlayerPrefs.SetInt("max_experience", 100);
        }
        if (PlayerPrefs.GetString("lives_isset") != "yes")
        {
            PlayerPrefs.SetString("lives_isset", "yes");
            PlayerPrefs.SetInt("lives", 5);
        }
        int lives = PlayerPrefs.GetInt("lives");
        int coins = PlayerPrefs.GetInt("coins");
        int exp = PlayerPrefs.GetInt("experience");
        int max_exp = PlayerPrefs.GetInt("max_experience");

        /*PlayerPrefs.SetInt("magic_item_solve_2d_puzzle", 5);
        PlayerPrefs.SetInt("magic_item_add_time_weak", 5);
        PlayerPrefs.SetInt("magic_item_add_time_middle", 5);
        PlayerPrefs.SetInt("magic_item_add_time_high", 5);*/

        coins_int.text = System.Convert.ToString(coins);
        lives_int.text = System.Convert.ToString(lives);
        exp_int.text = System.Convert.ToString(exp + "/" + max_exp);

    }

    public void LivesCountMinus()
    {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
    }

    public void UpadteInfo()
    {
        if (PlayerPrefs.GetInt("experience") >= PlayerPrefs.GetInt("max_experience"))
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
        int exp = 20;
        int coins = Random.Range(15, 30);
        int item = Random.Range(1, 21);

        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
        PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") + exp);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);

        plates_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = false;

        plates_rewards.SetActive(true);
        if(plates_rewards_magicitem!=null)
            plates_rewards_magicitem = plates_rewards.transform.Find("Reward MagicItemSolvePuzzle2D").gameObject;
        if (item==1)
        {
            PlayerPrefs.SetInt("magic_item_solve_2d_puzzle", PlayerPrefs.GetInt("magic_item_solve_2d_puzzle")+1);
        }
        else
            plates_rewards_magicitem.SetActive(false);
        plates_rewards.transform.Find("Reward EXP Int").GetComponent<Text>().text = exp.ToString();
        plates_rewards.transform.Find("Reward Coins Int").GetComponent<Text>().text = coins.ToString();

        need = true;
        game = "plates";
    }

    public void StartGamePlates()
    {
        if (PlayerPrefs.GetInt("lives") > 0)
        {
            LivesCountMinus();
            plates_interface.SetActive(false);
            plates_game_interface.SetActive(true);
            plates_game_interface.GetComponentInChildren<PlatesPuzzle>().onStart();
            plates_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = true;
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
            findsibling_game_interface.GetComponentInChildren<ResetGameFindSibling>().onStart();
            findsibling_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = true;
            PlayerPrefs.SetInt("sibling_pairs", 0);
            PlayerPrefs.SetString("sibling", "x");
            PlayerPrefs.SetInt("need_findsibling", 0);
            findsibling_game_interface.GetComponentInChildren<PuzzleTimer>().OnStart();
        }
    }
    public void AfterGameFindSibling()
    {
        int exp = 10;
        int coins = Random.Range(10, 20);

        PlayerPrefs.SetInt("sibling_pairs", 0);
        PlayerPrefs.SetString("sibling", "x");

        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
        PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") + exp);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
        findsibling_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = false;

        findsibling_rewards.SetActive(true);
        findsibling_rewards.transform.Find("Reward EXP Int").GetComponent<Text>().text = exp.ToString();
        findsibling_rewards.transform.Find("Reward Coins Int").GetComponent<Text>().text = coins.ToString();

        need = true;
        game = "findsibling";
    }

    public void LoseGameFindSibling()
    {
        _interface.SetActive(true);
        findsibling_game_interface.SetActive(false);
        UpadteInfo();
    }

    private void Update()
    {
        if (need && Input.GetMouseButton(0))
        {
            if (game == "findsibling")
            {
                findsibling_rewards.SetActive(false);
                _interface.SetActive(true);
                swiping.SetActive(true);
                findsibling_game_interface.SetActive(false);

                UpadteInfo();
            }
            else if (game == "plates")
            {
                _interface.SetActive(true);
                plates_rewards.SetActive(false);
                plates_game_interface.SetActive(false);
                swiping.SetActive(true);

                UpadteInfo();
            }
            else if (game == "followingplates")
            {
                _interface.SetActive(true);
                followingplates_rewards.SetActive(false);
                followingplates_game_interface.SetActive(false);
                swiping.SetActive(true);

                UpadteInfo();
            }
            need = false;
        }
    }


    public void AddLives()
    {
        PlayerPrefs.SetInt("lives", 5);
        UpadteInfo();
    }

    public void StartGameFollowingPlates()
    {
        if (PlayerPrefs.GetInt("lives") > 0)
        {
            LivesCountMinus();
            followingplates_interface.SetActive(false);
            followingplates_game_interface.SetActive(true);
            followingplates_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = true;
            followingplates_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = true;
            followingplates_game_interface.GetComponentInChildren<PuzzleTimer>().OnStart();
            for (int i = 1; i <= 9; i++)
            {
                PlayerPrefs.SetInt("followingplate" + i, Random.Range(1, 6));
            }
            PlayerPrefs.SetInt("following_puzzle_stage", 1);
            followingplates_game_interface.GetComponentInChildren<FollowingPuzzleScript>().StartGame();
        }
    }

    public void AfterGameFollowingPlates()
    {
        int exp = 15;
        int coins = Random.Range(15, 25);
        int item = Random.Range(1, 51);

        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
        PlayerPrefs.SetInt("experience", PlayerPrefs.GetInt("experience") + exp);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);

        followingplates_game_interface.GetComponentInChildren<PuzzleTimer>().enabled = false;

        followingplates_rewards.SetActive(true);
        if (followingplates_rewards_magicitem != null)
            followingplates_rewards_magicitem = plates_rewards.transform.Find("Reward MagicItemAddTimeWeak").gameObject;
        if (item == 1)
        {
            PlayerPrefs.SetInt("magic_item_add_time_weak", PlayerPrefs.GetInt("magic_item_add_time_weak") + 1);
        }
        else
            followingplates_rewards_magicitem.SetActive(false);
        followingplates_rewards.transform.Find("Reward EXP Int").GetComponent<Text>().text = exp.ToString();
        followingplates_rewards.transform.Find("Reward Coins Int").GetComponent<Text>().text = coins.ToString();

        need = true;
        game = "followingplates";
    }

    public void LoseGameFollowingPlates()
    {
        _interface.SetActive(true);
        followingplates_game_interface.SetActive(false);
        UpadteInfo();
    }
}
