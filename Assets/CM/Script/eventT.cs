using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventT : MonoBehaviour
{
    GameObject ATKinfo;

    // Start is called before the first frame update
    void Start()
    {
        ATKinfo = GameObject.FindGameObjectWithTag("ATKinfo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player" && this.gameObject.tag == "sword")
        {


        }
    }
}
