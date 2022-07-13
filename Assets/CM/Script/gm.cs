using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
    public GameObject[] _Ground;
    public GameObject[] Box;
    GameObject[] spawnPoints;
    GameObject currentPoint;

    public int count = 5;
    int index;

    List<int> rangeList = new List<int>();

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("_ground");
        SaveToList();

        for (int i = 0; i < rangeList.Count; i++)
        {
            Debug.Log("生成物件");
            //currentPoint = spawnPoints[rangeList[i]];
            Instantiate(Box[i], spawnPoints[rangeList[i]].transform.position, Quaternion.identity);
        }

        /*
                //隨機生成物件在地圖物件上
                for (int i = 0; i < 5; i++)
                {
                    spawnPoints = GameObject.FindGameObjectsWithTag("_ground");
                    index = Random.Range(0, spawnPoints.Length);
                    currentPoint = spawnPoints[index];
                    Instantiate(Box[i], spawnPoints[index].transform.position, Quaternion.identity);
                }
        */
    }

    void Update()
    {

    }

    void SaveToList()
    {

        while (rangeList.Count < count)
        {
            index = Random.Range(0, spawnPoints.Length);

            if (!rangeList.Contains(index))
            {
                rangeList.Add(index);
            }
            else
            {
                continue;
            }

        }
    }

}