using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesPuzzle : MonoBehaviour
{
    public MonoBehaviour[,] puzzleobj = new MonoBehaviour[3, 3];
    public MonoBehaviour plate1;
    public MonoBehaviour plate2;
    public MonoBehaviour plate3;
    public MonoBehaviour plate4;
    public MonoBehaviour plate5;
    public MonoBehaviour plate6;
    public MonoBehaviour plate7;
    public MonoBehaviour plate8;
    public MonoBehaviour plate9;
    private MonoBehaviour obj_for_move;
    private Vector3 coord_obj_to_move;
    private GameObject controller;
    private int i;
    private int j;
    private int temp=0;
    private bool move;
    void Start()
    {
        int rand = Random.Range(1, 3);
        if (rand==1)
        {
            puzzleobj[0, 0] = plate1;
            puzzleobj[0, 1] = plate2;
            puzzleobj[0, 2] = plate3;
            puzzleobj[1, 0] = plate4;
            puzzleobj[1, 1] = plate5;
            puzzleobj[1, 2] = plate6;
            puzzleobj[2, 0] = plate7;
            puzzleobj[2, 1] = plate8;

        }
        else if (rand==2)
        {
            puzzleobj[0, 0] = plate1;
            puzzleobj[0, 1] = plate2;
            puzzleobj[0, 2] = plate3;
            puzzleobj[1, 0] = plate4;
            puzzleobj[1, 1] = plate5;
            puzzleobj[1, 2] = plate6;
            puzzleobj[2, 0] = plate7;
            puzzleobj[2, 1] = plate8;
        }
        else
        {
            puzzleobj[0, 0] = plate1;
            puzzleobj[0, 1] = plate2;
            puzzleobj[0, 2] = plate3;
            puzzleobj[1, 0] = plate4;
            puzzleobj[1, 1] = plate5;
            puzzleobj[1, 2] = plate6;
            puzzleobj[2, 0] = plate7;
            puzzleobj[2, 1] = plate8;
        }
    }
    
    public void CheckWin()
    {
        if(puzzleobj[0,0]==plate1 && puzzleobj[0,1]==plate2 && puzzleobj[0,2]==plate3 &&
            puzzleobj[1,0]==plate4 && puzzleobj[1,1]==plate5 && puzzleobj[1,2]==plate6 &&
            puzzleobj[2,0]==plate7 && puzzleobj[2,1]==plate8)
        {
            controller = GameObject.Find("Interface Main");
            controller.GetComponent<StartGame>().AfterGamePlates();
        }
    }
    public void PlateMoving(MonoBehaviour to_move,Vector2 new_coords)
    {
        obj_for_move = to_move;
        coord_obj_to_move = new_coords;
    }

    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            if (obj_for_move != null && obj_for_move.GetComponent<Transform>().transform.position != coord_obj_to_move)
                if (temp < 15)
                {
                    temp++;
                    obj_for_move.GetComponent<Transform>().transform.position = Vector2.Lerp(obj_for_move.GetComponent<Transform>().transform.position, coord_obj_to_move, 10f * Time.deltaTime);
                }
                else
                {
                    temp = 0;
                    obj_for_move.GetComponent<Transform>().transform.position = coord_obj_to_move;
                }
        }
    }
}
