using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
public class CardManager : TSingletonMonoBehavior<CardManager>
{
    GameObject container;
    public delegate void CreateCardEvent(string prefix);
    // Start is called before the first frame update
    private void Awake() {
        container = GameObject.Find("Canvas");        
    }
    void Start()
    {        
        //CreateCard("Forward", printCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCard(int cardType){
        printCard(cardType);
    }
    
    void printCard(int cardType){
        if(cardType == 0){
            GameObject cardNPC = ObjectPool.Instance.GetForwardPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);           
            Debug.Log(cardNPC);
        }else if(cardType == 1){
            GameObject cardNPC = ObjectPool.Instance.GetBackPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);           
        }else if(cardType == 2){
            GameObject cardNPC = ObjectPool.Instance.GetRightPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);           
        }else if(cardType == 3){
            GameObject cardNPC = ObjectPool.Instance.GetLeftPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);           
        }
    }
}
