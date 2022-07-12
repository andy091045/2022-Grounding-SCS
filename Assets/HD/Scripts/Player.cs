using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
public class Player : TSingletonMonoBehavior<Player>
{
    public float PlayerMoveTime = 2.0f;
    public float PlayerSpeed = 10.0f; 

    public int hp = 100;
    public int atk = 20;
    public int def = 15;

    public int addAtk = 5;
    public int addDef = 20;
    public int addHp = 50;    

    //觸發的四種事件: 沒觸發事件、遭遇敵人、遭遇寶箱、遭遇隨機事件
    public int triggerType = 0;

    public void TurnForward(){               
        StartCoroutine(Move(PlayerMoveTime, "Forward")); 
        StateManager.Instance.ButtonClick = true;
    }
    public void TurnBack(){               
        StartCoroutine(Move(PlayerMoveTime, "Back"));  
        StateManager.Instance.ButtonClick = true;      
    }
    public void TurnRight(){               
        StartCoroutine(Move(PlayerMoveTime, "Right")); 
        StateManager.Instance.ButtonClick = true;       
    }
    public void TurnLeft(){               
        StartCoroutine(Move(PlayerMoveTime, "Left")); 
        StateManager.Instance.ButtonClick = true;       
    }

     private IEnumerator Move (float time, string way){
        //PlayerRotate(way);
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

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "enemy"){
            triggerType = 1;
            Destroy(other.gameObject);
            Debug.Log("遭遇敵人!");
        }else if(other.tag == "sword"){
            triggerType = 2;
            Destroy(other.gameObject);
            Debug.Log("隨機事件!");
        }else if(other.tag == "shield"){
            triggerType = 3;
            Destroy(other.gameObject);
            Debug.Log("遭遇寶箱!");
        }else if(other.tag == "event1"){
            triggerType = 4;
            Destroy(other.gameObject);
            Debug.Log("遭遇隱藏事件1!");
        }else if(other.tag == "event2"){
            triggerType = 5;
            Destroy(other.gameObject);
            Debug.Log("遭遇隱藏事件2!");
        }else if(other.tag == "event3"){
            triggerType = 6;
            Destroy(other.gameObject);
            Debug.Log("遭遇隱藏事件3!");
        }else if(other.tag == "airWall"){           
            
            Debug.Log("玩家死亡");
        }
        
    }
}
