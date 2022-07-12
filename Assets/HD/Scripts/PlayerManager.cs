using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float PlayerSpeed = 0.02f;
    public float PlayerMoveTime = 0.5f;
    string beforeWay = "Forward";
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TurnForward(){        
        StartCoroutine(Move(PlayerMoveTime, "Forward"));
        beforeWay = "Forward";
    }

    public void TurnBack(){        
        StartCoroutine(Move(PlayerMoveTime, "Back"));
        beforeWay = "Back";
    }

    public void TurnRight(){     
        StartCoroutine(Move(PlayerMoveTime, "Right"));
        beforeWay = "Right";
    }

    public void TurnLeft(){        
        StartCoroutine(Move(PlayerMoveTime, "Left"));
        beforeWay = "Left";
    }

    private IEnumerator Move (float time, string way){
        PlayerRotate(way);
        if(way == "Forward"){
            float t = 0;
            while(true)
            {
                t += Time.deltaTime;
                float a = t/ time;
                this.transform.position += new Vector3(0, 0, PlayerSpeed * Time.deltaTime);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }else if(way == "Back"){
            float t = 0;
            while(true)
            {
                t += Time.deltaTime;
                float a = t/ time;
                this.transform.position += new Vector3(0, 0, - PlayerSpeed * Time.deltaTime);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }else if(way == "Right"){
            float t = 0;
            while(true)
            {
                t += Time.deltaTime;
                float a = t/ time;
                this.transform.position += new Vector3( PlayerSpeed * Time.deltaTime, 0, 0);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }else if(way == "Left"){
            float t = 0;
            while(true)
            {
                t += Time.deltaTime;
                float a = t/ time;
                this.transform.position += new Vector3( - PlayerSpeed * Time.deltaTime, 0, 0);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }
    }

    //目前旋轉是瞬間旋轉，若之後有時間再進行調整改成慢慢旋轉
    void PlayerRotate(string way){
        if(beforeWay == "Forward"){
            switch (way)
            {
                case "Forward":
                    Debug.Log("不用旋轉");
                    break;
                case "Back":
                    Debug.Log("轉180度");
                    this.transform.Rotate(0, 180.0f, 0);                    
                    break;
                case "Right":
                    this.transform.Rotate(0, 90.0f, 0);
                    Debug.Log("轉90度");
                    break;
                case "Left":
                    this.transform.Rotate(0, 270.0f, 0);
                    Debug.Log("轉270度");
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
        }else if(beforeWay == "Back"){
            switch (way)
            {
                case "Forward":
                    Debug.Log("轉180度");
                    this.transform.Rotate(0, 180.0f, 0);   
                    break;
                case "Back":
                    Debug.Log("不用旋轉");                    
                    break;
                case "Right":
                    this.transform.Rotate(0, 270.0f, 0);
                    Debug.Log("轉270度");
                    break;
                case "Left":
                    this.transform.Rotate(0, 90.0f, 0);
                    Debug.Log("轉90度");                    
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
        }else if(beforeWay == "Right"){
            switch (way)
            {
                case "Forward":
                    this.transform.Rotate(0, 270.0f, 0);
                    Debug.Log("轉270度");                       
                    break;
                case "Back":
                    this.transform.Rotate(0, 90.0f, 0);
                    Debug.Log("轉90度");
                    break;
                case "Right":
                    Debug.Log("不用旋轉");                         
                    break;
                case "Left":
                    Debug.Log("轉180度");
                    this.transform.Rotate(0, 180.0f, 0);                                       
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
        }else if(beforeWay == "Left"){
            switch (way)
            {
                case "Forward":
                    this.transform.Rotate(0, 90.0f, 0);
                    Debug.Log("轉90度");
                    break;
                case "Back":
                    this.transform.Rotate(0, 270.0f, 0);
                    Debug.Log("轉270度");
                    break;
                case "Right":
                    Debug.Log("轉180度");
                    this.transform.Rotate(0, 180.0f, 0);                   
                    break;
                case "Left":
                    Debug.Log("不用旋轉");                                    
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
        }
        
        
    }
}
