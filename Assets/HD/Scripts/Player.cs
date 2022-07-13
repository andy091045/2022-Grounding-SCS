using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HD.Singleton;
public class Player : TSingletonMonoBehavior<Player>
{
    public int bossPower = 0;
    public int playerPower = 0;
    public float PlayerMoveTime = 2.0f;
    public float PlayerSpeed = 10.0f;

    public int hp = 100;
    public int atk = 50;
    public int def = 30;

    public int addAtk = 5;
    public int addDef = 20;
    public int addHp = 50;

    public int subtractHp = 10;

    bool triggerWall = false;

    static public bool isDead = false;
    static public bool isWin = false;

    //觸發的四種事件: 沒觸發事件、遭遇敵人、遭遇寶箱、遭遇隨機事件
    public int triggerType = 0;

    //事件物件
    public GameObject ATK_info, DEF_info, Event_HP_info, Trap_HP_info, Enemy_info, Win_info, Lose_info;

    //ATK和DEF的ICON
    public Image iATK, iDEF;

    //HP
    public Text HP, Level;

private void Awake() {
    Lose_info.SetActive(false);
    isDead = false;
    isWin = false;
}

    private void Start()
    {
        bossPower = Power(200, 100, 50);
        playerPower = Power(hp, atk, def);
    }

    private void Update()
    {
        IsDead();

        //HPtoText
        HP.text = hp.ToString();

        //LeveltoText
        Level.text = StateManager.Instance.level.ToString();

    }

    public int Power(int hp, int atk, int def)
    {
        return hp + atk * 3 + def * 2;
    }

    void PlayerPowerState()
    {
        playerPower = Power(hp, atk, def);
        if (playerPower <= 450)
        {
            Debug.Log("Boss顯示紅色");
        }
        else
        {
            Debug.Log("Boss顯示黃色");
        }
    }


    void IsDead()
    {
        if (hp <= 0 || StateManager.Instance.level <= 0 || triggerWall)
        {
            isDead = true;
            Debug.Log("玩家死亡");
            Lose_info.SetActive(true);
        }
    }

    public void TurnForward()
    {
        StartCoroutine(Move(PlayerMoveTime, "Forward"));
        StateManager.Instance.ButtonClick = true;
    }
    public void TurnBack()
    {
        StartCoroutine(Move(PlayerMoveTime, "Back"));
        StateManager.Instance.ButtonClick = true;
    }
    public void TurnRight()
    {
        StartCoroutine(Move(PlayerMoveTime, "Right"));
        StateManager.Instance.ButtonClick = true;
    }
    public void TurnLeft()
    {
        StartCoroutine(Move(PlayerMoveTime, "Left"));
        StateManager.Instance.ButtonClick = true;
    }

    private IEnumerator Move(float time, string way)
    {
        //PlayerRotate(way);
        if (way == "Forward")
        {
            float t = 0;
            while (true)
            {
                t += Time.deltaTime;
                float a = t / time;
                this.transform.position += new Vector3(0, 0, PlayerSpeed * Time.deltaTime);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }
        else if (way == "Back")
        {
            float t = 0;
            while (true)
            {
                t += Time.deltaTime;
                float a = t / time;
                this.transform.position += new Vector3(0, 0, -PlayerSpeed * Time.deltaTime);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }
        else if (way == "Right")
        {
            float t = 0;
            while (true)
            {
                t += Time.deltaTime;
                float a = t / time;
                this.transform.position += new Vector3(PlayerSpeed * Time.deltaTime, 0, 0);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }
        else if (way == "Left")
        {
            float t = 0;
            while (true)
            {
                t += Time.deltaTime;
                float a = t / time;
                this.transform.position += new Vector3(-PlayerSpeed * Time.deltaTime, 0, 0);
                if (a >= 1.0f)
                    break;
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            triggerType = 1;
            Destroy(other.gameObject);
            atk += Random.Range(10, 40);
            hp -= Random.Range(30, 60);
            PlayerPowerState();
            Debug.Log("遭遇敵人!");
            Enemy_info.SetActive(true);
        }
        else if (other.tag == "sword")
        {
            triggerType = 2;
            Destroy(other.gameObject);
            atk += 50;
            PlayerPowerState();
            Debug.Log("寶箱寶劍!");
            ATK_info.SetActive(true);
            iATK.color = new Color32(255, 255, 255, 255);
        }
        else if (other.tag == "shield")
        {
            triggerType = 3;
            Destroy(other.gameObject);
            def += 40;
            PlayerPowerState();
            Debug.Log("寶箱盾牌!");
            DEF_info.SetActive(true);
            iDEF.color = new Color32(255, 255, 255, 255);
        }
        else if (other.tag == "event1")
        {
            triggerType = 4;
            Destroy(other.gameObject);
            hp += Random.Range(50, 80);
            PlayerPowerState();
            Debug.Log("隱藏事件1回血!");
            Event_HP_info.SetActive(true);
            hp += addHp;
        }
        else if (other.tag == "event2")
        {
            triggerType = 5;
            Destroy(other.gameObject);
            hp -= 20;
            PlayerPowerState();
            Debug.Log("隱藏事件2!減血");
            Trap_HP_info.SetActive(true);
        }
        else if (other.tag == "event3")
        {
            triggerType = 6;
            Destroy(other.gameObject);
            Debug.Log("遭遇隱藏事件3!");
        }
        else if (other.tag == "airWall")
        {
            triggerWall = true;
            Lose_info.SetActive(true);
        }
        else if (other.tag == "bossWall")
        {
            if (playerPower > bossPower)
            {
                isWin = true;
                Win_info.SetActive(true);
            }
            else if (playerPower <= bossPower && playerPower > 500)
            {
                int x = Random.Range(0, 2);
                if (x == 1)
                {
                    isWin = true;
                    Win_info.SetActive(true);
                }
                else
                {
                    isDead = true;
                    Lose_info.SetActive(true);
                }
            }
            else
            {
                isDead = true;
                Lose_info.SetActive(true);
            }
        }

    }

}
