using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
public class CardManager : TSingletonMonoBehavior<CardManager>
{
    public List<GameObject> CardLibrary;
    GameObject container;
    public GameObject[] Cardpos;
    public delegate void CreateCardEvent(string prefix);
    static public bool _cardNPC = false;
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
        if (_cardNPC == true)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Card");
            objects[0].transform.position = Cardpos[0].transform.position;
            objects[1].transform.position = Cardpos[1].transform.position;
            objects[2].transform.position = Cardpos[2].transform.position;
            objects[3].transform.position = Cardpos[3].transform.position;
            objects[4].transform.position = Cardpos[4].transform.position;
        }
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
                _cardNPC = true;            
            }
            
        }else if(cardType == 1){
            GameObject cardNPC = ObjectPool.Instance.GetBackPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true); 
            CardLibrary.Add(cardNPC); 
            _cardNPC = true;          
        }else if(cardType == 2){
            GameObject cardNPC = ObjectPool.Instance.GetRightPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);  
            CardLibrary.Add(cardNPC); 
            _cardNPC = true;         
        }else if(cardType == 3){
            GameObject cardNPC = ObjectPool.Instance.GetLeftPooledObject();
            cardNPC.transform.parent = container.transform;
            cardNPC.SetActive(true);  
            CardLibrary.Add(cardNPC);  
            _cardNPC = true;        
        }
    }
}
