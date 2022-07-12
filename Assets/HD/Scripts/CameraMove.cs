using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public float CameraSpeed = 0.1f;
    public float upBorder = 10.0f;
    public float downBorder = -10.0f;
    public float rightBorder = 10.0f;
    public float leftBorder = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

       void Update()
    {
        Move();
    }

    void Move()
    {
        //如果玩家按下右鍵
        if (Input.GetKey(KeyCode.RightArrow))
        {        
            //相機不能超出邊界    
            if(this.transform.position.x < rightBorder){
                //Camera向右移動
                this.transform.position += new Vector3(CameraSpeed, 0, 0);
            }
            
        }

        //如果玩家按下左鍵
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //相機不能超出邊界    
            if(this.transform.position.x > leftBorder){
                //Camera向左移動
                this.transform.position += new Vector3(-CameraSpeed, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {            
            //相機不能超出邊界    
            if(this.transform.position.z < upBorder){
                //Camera向前移動
                this.transform.position += new Vector3(0, 0, CameraSpeed);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //相機不能超出邊界    
            if(this.transform.position.z > downBorder){
                //Camera向後移動
                this.transform.position += new Vector3(0, 0, -CameraSpeed);
            }
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            //Debug.Log("想做相機位置重置但沒做出來");
            this.transform.position = player.transform.position + new Vector3(0.0f, 10.0f, -10.0f); 
            Debug.Log(transform.position);
        }
    }

}
