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

    private GameObject obj_for_move;

    private Vector3 coord_obj_to_move;

    private GameObject controller;
    private Text not_move;
    private Color color_not;
    private float time = 0.05f;

    private int puzzle_var;
    public bool moved;

    private int i;
    private int j;
    private int temp=0;
    private bool move;

    private void Start()
    {
        not_move = GameObject.Find("Not Move").GetComponent<Text>();
        color_not = not_move.color;
        not_move.gameObject.SetActive(false);
    }
    public void onStart()
    {
        moved = true;
        puzzle_var = Random.Range(1, 4);
        if (puzzle_var == 1)
        {
            puzzleobj[0, 0] = plate1;
            plate1.transform.position = Cplate1.transform.position;

            puzzleobj[0, 1] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - Screen.width * 3 / 21.6f, Cplate9.transform.position.y + Screen.width * 6 / 21.6f);

            puzzleobj[0, 2] = plate4;
            plate4.transform.position = new Vector2(Cplate4.transform.position.x + Screen.width * 6 / 21.6f, Cplate4.transform.position.y + Screen.width * 3 / 21.6f);

            puzzleobj[1, 1] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + Screen.width * 3 / 21.6f, Cplate7.transform.position.y + Screen.width * 3 / 21.6f);

            puzzleobj[1, 2] = plate6;
            plate6.transform.position = Cplate6.transform.position;

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - Screen.width * 3 / 21.6f, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x - Screen.width * 3 / 21.6f, Cplate3.transform.position.y - Screen.width * 6 / 21.6f);

            puzzleobj[2, 2] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x + Screen.width * 3 / 21.6f, Cplate2.transform.position.y - Screen.width * 6 / 21.6f);

        }
        else if (puzzle_var == 2)
        {
            puzzleobj[0, 0] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x - Screen.width * 6 / 21.6f, Cplate3.transform.position.y);

            puzzleobj[0, 1] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - Screen.width * 3 / 21.6f, Cplate9.transform.position.y + Screen.width * 6 / 21.6f);

            puzzleobj[0, 2] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + Screen.width * 6 / 21.6f, Cplate7.transform.position.y + Screen.width * 6 / 21.6f);

            puzzleobj[1, 0] = plate4;
            plate4.transform.position = Cplate4.transform.position;

            puzzleobj[1, 1] = plate1;
            plate1.transform.position = new Vector2(Cplate1.transform.position.x + Screen.width * 3 / 21.6f, Cplate1.transform.position.y - Screen.width * 3 / 21.6f);

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - Screen.width * 3 / 21.6f, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x, Cplate2.transform.position.y - Screen.width * 6 / 21.6f);

            puzzleobj[2, 2] = plate6;
            plate6.transform.position = new Vector2(Cplate6.transform.position.x, Cplate6.transform.position.y - Screen.width * 3 / 21.6f);

        }
        else
        {
            puzzleobj[0, 0] = plate6;
            plate6.transform.position = new Vector2(Cplate6.transform.position.x - Screen.width * 6 / 21.6f, Cplate6.transform.position.y + Screen.width * 3 / 21.6f);

            puzzleobj[0, 1] = plate4;
            plate4.transform.position = new Vector2(Cplate4.transform.position.x + Screen.width * 3 / 21.6f, Cplate4.transform.position.y + Screen.width * 3 / 21.6f);

            puzzleobj[0, 2] = plate7;
            plate7.transform.position = new Vector2(Cplate7.transform.position.x + Screen.width * 6 / 21.6f, Cplate7.transform.position.y + Screen.width * 6 / 21.6f);

            puzzleobj[1, 0] = plate9;
            plate9.transform.position = new Vector2(Cplate9.transform.position.x - Screen.width * 6 / 21.6f, Cplate9.transform.position.y + Screen.width * 3 / 21.6f);

            puzzleobj[1, 2] = plate1;
            plate1.transform.position = new Vector2(Cplate1.transform.position.x + Screen.width * 6 / 21.6f, Cplate1.transform.position.y - Screen.width * 3 / 21.6f);

            puzzleobj[2, 0] = plate8;
            plate8.transform.position = new Vector2(Cplate8.transform.position.x - Screen.width * 3 / 21.6f, Cplate8.transform.position.y);

            puzzleobj[2, 1] = plate2;
            plate2.transform.position = new Vector2(Cplate2.transform.position.x, Cplate2.transform.position.y - Screen.width * 6 / 21.6f);

            puzzleobj[2, 2] = plate3;
            plate3.transform.position = new Vector2(Cplate3.transform.position.x, Cplate3.transform.position.y - Screen.width * 6 / 21.6f);

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
            controller = GameObject.Find("Interface Main");
            controller.GetComponent<StartGame>().AfterGamePlates();
        }
    }
    public void PlateMoving(GameObject to_move,Vector2 new_coords)
    {
        moved = false;
        obj_for_move = to_move;
        coord_obj_to_move = new_coords;
    }

    public void CantMove()
    {
        not_move.gameObject.SetActive(true);
        color_not.a = 1;
        not_move.color = color_not;
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
            if (color_not.a > 0)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    time = 0.05f;
                    color_not.a = not_move.color.a - 0.09f;
                    not_move.color = color_not;
                    if (not_move.color.a <= 0)
                    {
                        not_move.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
