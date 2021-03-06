﻿using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameController : MonoBehaviour
{

    [Header("Generation")]
    public GameObject[] roomPrefab;
    public GameObject leftBlock;
    public GameObject rightBlock;
    public GameObject topBlock;
    public GameObject bottomBlock;
    [Space]
    public GameObject roomDetector;


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
        int rooms = 1;

        map[posX, posY] = 1;

        for(; rooms < 10;)
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

            if(map[posX, posY] != 1)
            {
                rooms += 1;
                map[posX, posY] = 1;
            }
            
        }


        for(int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                if(map[x, y] == 1)
                {
                    if((x > 0 && map[x - 1, y] == 0) || x == 0)
                    {
                        Instantiate(leftBlock, new Vector2((x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    }
                    if((x < 8 && map[x + 1, y] == 0) || x == 8)
                    {
                        Instantiate(rightBlock, new Vector2((x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    }
                    if((y > 0 && map[x, y - 1] == 0) || y == 0)
                    {
                        Instantiate(topBlock, new Vector2((x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    }
                    if((y < 8 && map[x, y+1] == 0) || y == 8)
                    {
                        Instantiate(bottomBlock, new Vector2((x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    }

                    Instantiate(roomPrefab[0], new Vector2(( x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    
                    if(x != 4 || y != 8)
                    {
                        print("a");
                        Instantiate(roomDetector, new Vector2((x) * (roomWidth - 1), (8 - y) * (roomHeight - 1)), Quaternion.identity, mapParent.transform);
                    }
                
                }
                
            }
        }
    }
}
