using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
public class CardManager : TSingletonMonoBehavior<CardManager>
{
    public List<GameObject> CardLibrary;
    GameObject container;
    public delegate void CreateCardEvent(string prefix);
    // Start is called before the first frame update
    private void Awake() {
        container = GameObject.Find("Canvas"); 
        CardLibrary = new List<GameObject>();     
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

    public void DeleteCard(){
        for (int i = 0; i < CardLibrary.Count; i++)
        {
            Destroy(CardLibrary[i].gameObject);
        }
    }
    
    void printCard(int cardType){
        if(cardType == 0){            
            GameObject cardNPC = ObjectPool.Instance.GetForwardPooledObject();
            if(cardNPC == null){
                Debug.Log("生成有問題");                
            }else{
                cardNPC.transform.parent = container.transform;
                cardNPC.SetActive(true); 
                CardLibrary.Add(cardNPC);             
            }
            
        }else if(cardType == 1){
            GameObject cardNPC = ObjectPool.Instance.GetBackPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true); 
            CardLibrary.Add(cardNPC);           
        }else if(cardType == 2){
            GameObject cardNPC = ObjectPool.Instance.GetRightPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);  
            CardLibrary.Add(cardNPC);          
        }else if(cardType == 3){
            GameObject cardNPC = ObjectPool.Instance.GetLeftPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);  
            CardLibrary.Add(cardNPC);          
        }
    }
}
