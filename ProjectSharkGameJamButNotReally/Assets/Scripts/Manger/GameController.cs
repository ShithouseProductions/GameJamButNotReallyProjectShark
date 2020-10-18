using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameController : MonoBehaviour
{

    [Header("Generation")]
    public GameObject[] roomPrefab;
    public GameObject[] enemyPrefab;


    [Header("GameObjects")]
    private GameObject mapParent;

    [Header("Tools")]
    public bool isPaused = false;
    private int roomWidth = 22;
    private int roomHeight = 14;


    void Start()
    {
        if(GameObject.Find("_Map") != null)
        {
            mapParent = GameObject.Find("_Map");
            GenerateMap();
        }

    }

    
    void Update()
    {
        
    }

    private void GenerateMap()
    {

        int[,] map = new int[9, 9];
        int posX = 4;
        int posY = 8;

        for(int i = 0; i < 10; i++)
        {
            int rand = Random.Range(1, 5);
            
            if(rand == 1) //FORWARD
            {
                if(posY != 0)
                {
                    posY -= 1;
                }
            }
            if(rand == 2) //LEFT
            {
                if(posX > 0)
                {
                    posX -= 1;
                }
            }
            if(rand == 3) //RIGHT
            {
                if(posX < 8)
                {
                    posX += 1;
                }
            }
            if(rand == 4) //DOWN
            {
                if(posY < 8)
                {
                    posY += 1;
                }
            }

            map[posX, posY] = 1;
        }


        for(int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                //map[0, 0] = 1;
                if(map[x, y] == 1)
                {
                    Instantiate(roomPrefab[0], new Vector2(x * 100, 0 + 8 - y * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                }
                
            }
        }
    }
}
