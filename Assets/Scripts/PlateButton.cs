using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateButton : MonoBehaviour
{
    private GameObject controller;
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
                print("moved x-1");
            }
        if (j - 1 >= 0)
            if (puzzleobj[i, j - 1] == null)
            {
                puzzleobj[i, j - 1] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i, j - 1, Obj);
                print("moved y-1");
            }
        if (j + 1 < 3)
            if (puzzleobj[i, j + 1] == null)
            {
                puzzleobj[i, j + 1] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i, j + 1, Obj);
                print("moved y+1");
            }
        if (i + 1 < 3)
            if (puzzleobj[i + 1, j] == null)
            {
                puzzleobj[i + 1, j] = Obj;
                puzzleobj[i, j] = null;
                Moving(i, j, i + 1, j, Obj);
                print("moved x+1");
            }
        if (!ismove)
            print("ÍÅËÜÇß ÏÅÐÅÄÂÈÍÓÒÜ!");
        
        controller.GetComponent<PlatesPuzzle>().CheckWin();
    }

    private void Moving(int i, int j, int ii, int jj,MonoBehaviour moved)
    {
        ismove = true;
        if (i!=ii)
            if(i>ii)
                moved.GetComponent<Transform>().transform.position = new Vector2(moved.GetComponent<Transform>().transform.position.x, moved.GetComponent<Transform>().transform.position.y + 150);//up?
            else
                moved.GetComponent<Transform>().transform.position = new Vector2(moved.GetComponent<Transform>().transform.position.x, moved.GetComponent<Transform>().transform.position.y - 150);//down?
        else if(j!=jj)
            if(j>jj)
                moved.GetComponent<Transform>().transform.position = new Vector2(moved.GetComponent<Transform>().transform.position.x - 150, moved.GetComponent<Transform>().transform.position.y);//left?
            else
                moved.GetComponent<Transform>().transform.position = new Vector2(moved.GetComponent<Transform>().transform.position.x + 150, moved.GetComponent<Transform>().transform.position.y);//right?
    }
}

