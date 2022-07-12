using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //偵測tag為Player就刪除物件或執行事件
        if (other.GetComponent<Collider>().tag == "Player" || other.GetComponent<Collider>().tag == "ITEM")
        {
            Destroy(this.gameObject);
            print("Destroy" + this.gameObject.name);
        }

        if (other.GetComponent<Collider>().tag == "Player" && gameObject.name == "HP(Clone)")
        {
            print("回血");
        }

        if (other.GetComponent<Collider>().tag == "Player" && gameObject.name == "ATK(Clone)")
        {
            print("攻擊力++");
        }

        if (other.GetComponent<Collider>().tag == "Player" && gameObject.name == "DEF(Clone)")
        {
            print("防禦力++");
        }

        if (other.GetComponent<Collider>().tag == "Player" && gameObject.name == "Monster(Clone)")
        {
            print("怪物事件");
        }

        if (other.GetComponent<Collider>().tag == "Player" && gameObject.name == "Trap(Clone)")
        {
            print("陷阱事件");
        }
    }
}
