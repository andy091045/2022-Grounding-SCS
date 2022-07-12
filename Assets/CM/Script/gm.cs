using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
    //public GameObject[] _Ground;
    public GameObject[] Box;
    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;


    void Start()
    {

        //隨機生成物件在地圖物件上
        for (int i = 0; i < 5; i++)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("_ground");
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];
            Instantiate(Box[i], spawnPoints[index].transform.position, Quaternion.identity);
        }

    }

    void Update()
    {
        
    }
}
