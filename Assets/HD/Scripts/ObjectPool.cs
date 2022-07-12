using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;

public class ObjectPool : TSingletonMonoBehavior<ObjectPool>
{
    //往上卡牌庫
    public List<GameObject> ForwardPooledObjects;
    public GameObject ForwardObjectToPool;

    //往下卡牌庫
    public List<GameObject> BackPooledObjects;
    public GameObject BackObjectToPool;

    //往右卡牌庫
    public List<GameObject> RightPooledObjects;
    public GameObject RightObjectToPool;

    //往左卡牌庫
    public List<GameObject> LeftPooledObjects;
    public GameObject LeftObjectToPool;

    //the number you need to generate
    public int amountToPool;

    public GameObject GetForwardPooledObject(){
        
        for ( int i = 0; i < amountToPool; i++ ) {                       
            //Use it if you are not using it
            if(ForwardPooledObjects[i] && !ForwardPooledObjects[i].activeInHierarchy){
               return ForwardPooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetBackPooledObject(){
        for ( int i = 0; i < amountToPool; i++ ) {
            //Use it if you are not using it
            if(BackPooledObjects[i] && !BackPooledObjects[i].activeInHierarchy){
                return BackPooledObjects[i];
            }
        }
        return null;
    }

       public GameObject GetRightPooledObject(){
        for ( int i = 0; i < amountToPool; i++ ) {
            //Use it if you are not using it
            if(RightPooledObjects[i] && !RightPooledObjects[i].activeInHierarchy){
                return RightPooledObjects[i];
            }
        }
        return null;
    }

        public GameObject GetLeftPooledObject(){
        for ( int i = 0; i < amountToPool; i++ ) {
            //Use it if you are not using it
            if(LeftPooledObjects[i] && !LeftPooledObjects[i].activeInHierarchy){
                return LeftPooledObjects[i];
            }
        }
        return null;
    }
    

    void Awake()
    {
        ForwardPooledObjects = new List<GameObject>();
        BackPooledObjects = new List<GameObject>();
        RightPooledObjects = new List<GameObject>();
        LeftPooledObjects = new List<GameObject>();

        GameObject tmp;
        GameObject tmp2;
        GameObject tmp3;
        GameObject tmp4;

        //create Objects and add into  pooledObjects
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(ForwardObjectToPool);
            tmp.SetActive(false);
            ForwardPooledObjects.Add(tmp);             
        }            

        //create Objects and add into  TargetPooledObjects
        for(int i = 0; i < amountToPool; i++)
        {
            tmp2 = Instantiate(BackObjectToPool);
            tmp2.SetActive(false);
            BackPooledObjects.Add(tmp2);     
        }    

          //create Objects and add into  TargetPooledObjects
        for(int i = 0; i < amountToPool; i++)
        {
            tmp3 = Instantiate(RightObjectToPool);
            tmp3.SetActive(false);
            RightPooledObjects.Add(tmp3);     
        }  

        //create Objects and add into  TargetPooledObjects
        for(int i = 0; i < amountToPool; i++)
        {
            tmp4 = Instantiate(LeftObjectToPool);
            tmp4.SetActive(false);
            LeftPooledObjects.Add(tmp4);     
        }      
    }
}
