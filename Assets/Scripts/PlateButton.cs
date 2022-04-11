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
    private MonoBehaviour[,] puzzleobj;
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

    private void Start()
    {
        not_move = GameObject.Find("Not Move").GetComponent<Text>();
        color_not = not_move.color;
        controller = GameObject.Find("Plates Puzzle Script");
        puzzleobj = controller.GetComponent<PlatesPuzzle>().puzzleobj;

    }
    public void OnCellClick(MonoBehaviour Obj)
    {
        ismove = false;
        flag = true;
        for (ii = 0; flag && ii <= 2; ii++)
        {
            for (jj = 0; flag && jj <= 2; jj++)
            {
                if (puzzleobj[ii, jj] == Obj)
                { i = ii; j = jj; flag = false;}
            }
        }
        if (i - 1 >= 0)
            if (puzzleobj[i - 1, j] == null)
            {
                puzzleobj[i - 1, j] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i - 1, j,Obj);
            }
        if (j - 1 >= 0)
            if (puzzleobj[i, j - 1] == null)
            {
                puzzleobj[i, j - 1] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i, j - 1, Obj);
            }
        if (j + 1 < 3)
            if (puzzleobj[i, j + 1] == null)
            {
                puzzleobj[i, j + 1] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i, j + 1, Obj);
            }
        if (i + 1 < 3)
            if (puzzleobj[i + 1, j] == null)
            {
                puzzleobj[i + 1, j] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i + 1, j, Obj);
            }
        if (!ismove)
        {
            color_not.a = 1;
            not_move.color = color_not;
        }
        
        controller.GetComponent<PlatesPuzzle>().CheckWin();
    }

    private void Moving(int i, int j, int ii, int jj,MonoBehaviour moved)
    {
        Vector2 new_coords = Vector2.zero;
        ismove = true;
        if (i != ii)
            if (i > ii)
            {
                new_coords = new Vector2(moved.GetComponent<Transform>().transform.position.x, moved.GetComponent<Transform>().transform.position.y + 300);//up
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved,new_coords);
            }
            else
            { 
                new_coords = new Vector2(moved.GetComponent<Transform>().transform.position.x, moved.GetComponent<Transform>().transform.position.y - 300);//down
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
        else if (j != jj)
            if (j > jj)
            { 
                new_coords = new Vector2(moved.GetComponent<Transform>().transform.position.x - 300, moved.GetComponent<Transform>().transform.position.y);//left
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
            else
            { 
                new_coords = new Vector2(moved.GetComponent<Transform>().transform.position.x + 300, moved.GetComponent<Transform>().transform.position.y);//right
                controller.GetComponent<PlatesPuzzle>().PlateMoving(moved, new_coords);
            }
    }

    private void Update()
    {
        if(color_not.a>0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0.05f;
                color_not.a = not_move.color.a-0.09f;
                not_move.color = color_not;
                
            }
        }
    }


}

