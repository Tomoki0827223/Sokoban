using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public GameObject playerPrehub;
    int[,] map;
    GameObject[,] field;

    // Start is called before the first frame update

    //int[] map = { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                {
                    return new Vector2Int(x, y);
                }
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }

        }
        return new Vector2Int(-1, -1);
    }

    void Start()
    {
        //map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        //PrintArray();

        //インスタンス
        //GameObject instance = Instantiate(playerPrehub,new Vector3(0,0,0), Quaternion.identity);


        map = new int[,]
        {
          {1,0,0,0,0 },
          {0,0,0,0,0 },
          {0,0,0,0,0 },
        };

        field = new GameObject
        [

            map.GetLength(0),
            map.GetLength(1)
        ];

        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    //GameObject instance = Instantiate
                    field[y, x] = Instantiate(playerPrehub, new Vector3(x, map.GetLength(0) - 1 - y, 0.0f), Quaternion.identity);
                }
                else
                {
                    field[y, x] = Instantiate(playerPrehub, new Vector3(x, map.GetLength(0) - y, 0.0f), Quaternion.identity);
                }
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }

        //if (map[moveTo] == 2)
        //{
        //    int velocity = moveTo - moveFrom;

        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //    if (!success)
        //    {
        //        return true;
        //    }
        //}

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;

    }

    // Update is called once per frame
    void Update()
    {

        //int playerIndex = GetPlayerIndex();

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{

        //    MoveNumber(1, playerIndex, playerIndex + 1);
        //    PrintArray();


        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    MoveNumber(1, playerIndex, playerIndex - 1);
        //    PrintArray();
        //}
    }
}
