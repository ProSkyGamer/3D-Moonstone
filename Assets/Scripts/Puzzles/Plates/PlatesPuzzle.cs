using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatesPuzzle : MonoBehaviour
{
    public GameObject[,] puzzleobj = new GameObject[3, 3];
    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;
    public GameObject plate5;
    public GameObject plate6;
    public GameObject plate7;
    public GameObject plate8;
    public GameObject plate9;

    public GameObject Cplate1;
    public GameObject Cplate2;
    public GameObject Cplate3;
    public GameObject Cplate4;
    public GameObject Cplate5;
    public GameObject Cplate6;
    public GameObject Cplate7;
    public GameObject Cplate8;
    public GameObject Cplate9;

    public GameObject Audio_On_Move_Plate;
    public GameObject Audio_On_Cant_Move_Plate;
    public GameObject Audio_Use_Add_Time;
    public GameObject Audio_Use_Solve_Item;

    [SerializeField] private GameObject int_text_solve_puzzle;
    [SerializeField] private GameObject int_text_add_time_weak;
    [SerializeField] private GameObject int_text_add_time_middle;
    [SerializeField] private GameObject int_text_add_time_high;

    [SerializeField] private GameObject not_move;

    private GameObject obj_for_move;

    private Vector3 coord_obj_to_move;

    private GameObject controller;
    private float time = 0.05f;

    private int puzzle_var;
    public bool moved;

    private int i;
    private int j;
    private int temp=0;
    private bool move;
    private float screen_move = Screen.width * 3 / 24f;

    private void Start()
    {
        controller = GameObject.Find("Interface Main");
    }
    public void onStart()
    {
        UpdateMagicItemQuantity();
        Audio_Use_Add_Time.SetActive(false);
        Audio_Use_Solve_Item.SetActive(false);
        Audio_On_Move_Plate.SetActive(false);
        Audio_On_Cant_Move_Plate.SetActive(false);
        moved = true;
        puzzle_var = Random.Range(1, 4);
        if (puzzle_var == 1)
        {
            puzzleobj[0, 0] = plate1;
            plate1.transform.position = Cplate1.transform.position;

            puzzleobj[0, 1] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - screen_move, Cplate9.transform.position.y + 2 * screen_move);

            puzzleobj[0, 2] = plate4;
            plate4.transform.position = new Vector2(Cplate4.transform.position.x + 2 * screen_move, Cplate4.transform.position.y + screen_move);

            puzzleobj[1, 0] = null;

            puzzleobj[1, 1] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + screen_move, Cplate7.transform.position.y + screen_move);

            puzzleobj[1, 2] = plate6;
            plate6.transform.position = Cplate6.transform.position;

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - screen_move, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x - screen_move, Cplate3.transform.position.y - 2 * screen_move);

            puzzleobj[2, 2] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x + screen_move, Cplate2.transform.position.y - 2 * screen_move);

        }
        else if (puzzle_var == 2)
        {
            puzzleobj[0, 0] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x - 2 * screen_move, Cplate3.transform.position.y);

            puzzleobj[0, 1] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - screen_move, Cplate9.transform.position.y + 2 * screen_move);

            puzzleobj[0, 2] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + 2 * screen_move, Cplate7.transform.position.y + 2 * screen_move);

            puzzleobj[1, 0] = plate4;
            plate4.transform.position = Cplate4.transform.position;

            puzzleobj[1, 1] = plate1;
            plate1.transform.position = new Vector2(Cplate1.transform.position.x + screen_move, Cplate1.transform.position.y - screen_move);

            puzzleobj[1, 2] = null;

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - screen_move, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x, Cplate2.transform.position.y - 2 * screen_move);

            puzzleobj[2, 2] = plate6;
            plate6.transform.position = new Vector2(Cplate6.transform.position.x, Cplate6.transform.position.y - screen_move);

        }
        else
        {
            puzzleobj[0, 0] = plate6;
            plate6.transform.position = new Vector2(Cplate6.transform.position.x - 2 * screen_move, Cplate6.transform.position.y + screen_move);

            puzzleobj[0, 1] = plate4;
            plate4.transform.position = new Vector2(Cplate4.transform.position.x + screen_move, Cplate4.transform.position.y + screen_move);

            puzzleobj[0, 2] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + 2 * screen_move, Cplate7.transform.position.y + 2 * screen_move);

            puzzleobj[1, 0] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - 2 * screen_move, Cplate9.transform.position.y + screen_move);

            puzzleobj[1, 1] = null;

            puzzleobj[1, 2] = plate1;
            plate1.transform.position = new Vector2(Cplate1.transform.position.x + 2 * screen_move, Cplate1.transform.position.y - screen_move);

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - screen_move, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x, Cplate2.transform.position.y - 2 * screen_move);

            puzzleobj[2, 2] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x, Cplate3.transform.position.y - 2 * screen_move);

        }
        foreach(GameObject g in puzzleobj)
        {
            if(g!=null)
                g.GetComponent<PlateButton>().onStart();
        }
    }
    
    public void CheckWin()
    {
        if(puzzleobj[0,0]==plate1 && puzzleobj[0,1]==plate2 && puzzleobj[0,2]==plate3 &&
            puzzleobj[1,0]==plate4 && puzzleobj[1,2]==plate6 &&
            puzzleobj[2,0]==plate7 && puzzleobj[2,1]==plate8 && puzzleobj[2, 2] == plate9)
        {
            controller.GetComponent<StartGame>().AfterGamePlates();
        }
    }
    public void PlateMoving(GameObject to_move,Vector2 new_coords)
    {
        moved = false;
        obj_for_move = to_move;
        coord_obj_to_move = new_coords;
        Audio_On_Move_Plate.SetActive(false);
        Audio_On_Move_Plate.SetActive(true);
    }

    public void CantMove()
    {
        not_move.SetActive(true);
        not_move.GetComponent<TextDissapear>().OnceMore();
        Audio_On_Cant_Move_Plate.SetActive(false);
        Audio_On_Cant_Move_Plate.SetActive(true);
    }
    public void InstantMove()
    {
        obj_for_move.GetComponent<Transform>().transform.position = coord_obj_to_move;
        moved = true;
    }

    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            if (obj_for_move != null && obj_for_move.GetComponent<Transform>().transform.position != coord_obj_to_move)
                if (temp < 12)
                {
                    temp++;
                    obj_for_move.GetComponent<Transform>().transform.position = Vector2.Lerp(obj_for_move.GetComponent<Transform>().transform.position, coord_obj_to_move, 10f * Time.deltaTime);
                }
                else
                {
                    moved = true;
                    temp = 0;
                    obj_for_move.GetComponent<Transform>().transform.position = coord_obj_to_move;
                }
        }
    }

    public void UsedSolveItem()
    {
        controller.GetComponent<StartGame>().AfterGamePlates();
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
}
