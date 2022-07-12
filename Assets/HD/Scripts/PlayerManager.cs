using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;

public class PlayerManager : TSingletonMonoBehavior<PlayerManager>
{    
    public int hp = 100;
    public int atk = 20;
    public int def = 15;

    public int addAtk = 5;
    public int addDef = 20;
    public int addHp = 50;    

    public int cardType = 0;
    //觸發的四種事件: 沒觸發事件、遭遇敵人、遭遇寶箱、遭遇隨機事件
    public int triggerType = 0;
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

    public void ButtonForward(){     
        StateManager.Instance.ButtonClick = true;
        cardType = 0;
    }    
    public void ButtonBack(){
       
        StateManager.Instance.ButtonClick = true;
        cardType = 1;
    } 
    public void ButtonRight(){
        
        StateManager.Instance.ButtonClick = true;
        cardType = 2;
    } 
    public void ButtonLeft(){
       
        StateManager.Instance.ButtonClick = true;
        cardType = 3;
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
                    break;
                case "Back":                    
                    this.transform.Rotate(0, 180.0f, 0);                    
                    break;
                case "Right":
                    this.transform.Rotate(0, 90.0f, 0);                    
                    break;
                case "Left":
                    this.transform.Rotate(0, 270.0f, 0);                    
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }
        }else if(beforeWay == "Back"){
            switch (way)
            {
                case "Forward":                    
                    this.transform.Rotate(0, 180.0f, 0);   
                    break;
                case "Back":                                        
                    break;
                case "Right":
                    this.transform.Rotate(0, 270.0f, 0);                    
                    break;
                case "Left":
                    this.transform.Rotate(0, 90.0f, 0);                                       
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
                    break;
                case "Back":
                    this.transform.Rotate(0, 90.0f, 0);                    
                    break;
                case "Right":                                             
                    break;
                case "Left":                    
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
                    break;
                case "Back":
                    this.transform.Rotate(0, 270.0f, 0);                    
                    break;
                case "Right":                    
                    this.transform.Rotate(0, 180.0f, 0);                   
                    break;
                case "Left":                                                        
                    break;
                default:
                    Debug.Log("Default case");
                    break;
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
        }
        
    }
}
