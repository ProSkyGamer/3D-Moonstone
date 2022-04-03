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
    private int i;
    private int j;
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
        /*for(i=0;i<=2;i++)
        {
            for(j=0;j<=2;j++)
            {
                var obj = puzzleobj[i, j].GetComponent<Transform>();
                print(obj.position.x);
            }
        }*/
    }
    
    public void CheckWin()
    {
        if(puzzleobj[0,0]==plate1 && puzzleobj[0,1]==plate2 && puzzleobj[0,2]==plate3 &&
            puzzleobj[1,0]==plate4 && puzzleobj[1,1]==plate5 && puzzleobj[1,2]==plate6 &&
            puzzleobj[2,0]==plate7 && puzzleobj[2,1]==plate8)
        {
            print("WIN");
        }
    }
    private void Moving(int i, int j,int ii,int jj)
    {

    }
}
