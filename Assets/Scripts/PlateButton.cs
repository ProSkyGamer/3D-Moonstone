using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateButton : MonoBehaviour
{
    private GameObject controller;
    private Text not_move;
    private Color color_not;
    private float time=0.05f;
    private GameObject[,] puzzleobj;
    private int i;
    private int j;
    private int ii;
    private int jj;
    private bool flag;
    private bool up;
    private bool left;
    private bool right;
    private bool down;
    private bool ismove=false;

    public void onStart()
    {
        controller = GameObject.Find("Plates Puzzle Script");
        puzzleobj = controller.GetComponent<PlatesPuzzle>().puzzleobj;

    }
    public void OnCellClick()
    {
        if (controller.GetComponent<PlatesPuzzle>().moved)
        {
            ismove = false;
            flag = true;
            for (ii = 0; flag && ii <= 2; ii++)
            {
                for (jj = 0; flag && jj <= 2; jj++)
                {
                    if (puzzleobj[ii, jj] == gameObject)
                    { i = ii; j = jj; flag = false; }
                }
            }
            if (i - 1 >= 0)
                if (puzzleobj[i - 1, j] == null)
                {
                    puzzleobj[i - 1, j] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i - 1, j, gameObject);
                }
            if (j - 1 >= 0)
                if (puzzleobj[i, j - 1] == null)
                {
                    puzzleobj[i, j - 1] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i, j - 1, gameObject);
                }
            if (j + 1 < 3)
                if (puzzleobj[i, j + 1] == null)
                {
                    puzzleobj[i, j + 1] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i, j + 1, gameObject);
                }
            if (i + 1 < 3)
                if (puzzleobj[i + 1, j] == null)
                {
                    puzzleobj[i + 1, j] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i + 1, j, gameObject);
                }
            if (!ismove)
            {
                controller.GetComponent<PlatesPuzzle>().CantMove();
            }

            controller.GetComponent<PlatesPuzzle>().CheckWin();
        }
        else
        {
            controller.GetComponent<PlatesPuzzle>().InstantMove();
            ismove = false;
            flag = true;
            for (ii = 0; flag && ii <= 2; ii++)
            {
                for (jj = 0; flag && jj <= 2; jj++)
                {
                    if (puzzleobj[ii, jj] == gameObject)
                    { i = ii; j = jj; flag = false; }
                }
            }
            if (i - 1 >= 0)
                if (puzzleobj[i - 1, j] == null)
                {
                    puzzleobj[i - 1, j] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i - 1, j, gameObject);
                }
            if (j - 1 >= 0)
                if (puzzleobj[i, j - 1] == null)
                {
                    puzzleobj[i, j - 1] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i, j - 1, gameObject);
                }
            if (j + 1 < 3)
                if (puzzleobj[i, j + 1] == null)
                {
                    puzzleobj[i, j + 1] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i, j + 1, gameObject);
                }
            if (i + 1 < 3)
                if (puzzleobj[i + 1, j] == null)
                {
                    puzzleobj[i + 1, j] = gameObject;
                    puzzleobj[i, j] = null;
                    Moving(i, j, i + 1, j, gameObject);
                }
            if (!ismove)
            {
                controller.GetComponent<PlatesPuzzle>().CantMove();
            }

            controller.GetComponent<PlatesPuzzle>().CheckWin();
        }
    }

    private void Moving(int i, int j, int ii, int jj,GameObject moved)
    {
        Vector2 new_coords = Vector2.zero;
        ismove = true;
        PlayerPrefs.SetInt("can_plate_move", 0);
        if (i != ii)
            if (i > ii)
            {
                new_coords = new Vector2(moved.transform.position.x, moved.transform.position.y + Screen.width * 3 / 21.6f);//up
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved,new_coords);
            }
            else
            { 
                new_coords = new Vector2(moved.transform.position.x, moved.transform.position.y - Screen.width * 3 / 21.6f);//down
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
        else if (j != jj)
            if (j > jj)
            { 
                new_coords = new Vector2(moved.transform.position.x - Screen.width * 3 / 21.6f, moved.transform.position.y);//left
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
            else
            { 
                new_coords = new Vector2(moved.transform.position.x + Screen.width * 3 / 21.6f, moved.transform.position.y);//right
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
    }
}

