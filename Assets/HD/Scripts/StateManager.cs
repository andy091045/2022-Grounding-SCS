
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;

public enum StateDef
{
    idle,
	chooseCard,
	playerMove,
    encounter,
    boss,
    end
}

public class StateManager : TSingletonMonoBehavior<StateManager>{
    //玩家死亡
    public bool playerDead = false;
    //玩家的總回和數
    public int level = 20;
    public bool DestroyCard = false; 


    //判斷是否有按按鈕
    public bool ButtonClick = false;
    //判斷玩家是否完成移動
    public bool moveComplete = false;
    //判斷事件是否結束
    public bool eventComplete = false;

    //玩家即將前進的方向
    public string way;
    //卡牌生成最左邊位置
    public GameObject startCardPosition;
    //卡牌之間間距
    public float cardsSpace = 10.0f;
    //一次卡牌生成數量
    public int cardNumber = 5;
    public IState currentState;
    private Dictionary<StateDef, IState> states = new Dictionary<StateDef, IState>();
    private void Awake(){
        states.Add(StateDef.idle, new Idle(this));
        states.Add(StateDef.chooseCard, new ChooseCard(this));
        states.Add(StateDef.playerMove, new PlayerMove(this));
        states.Add(StateDef.encounter, new Encounter(this));
        states.Add(StateDef.boss, new Boss(this));
        states.Add(StateDef.end, new End(this));
        //默認狀態為選擇卡牌
        TransitionState(StateDef.idle);
    }

    private void Update(){
        currentState.OnUpdate();
        if(Input.GetKeyDown(KeyCode.W)){            
            TransitionState(StateDef.chooseCard);            
        }        
    }

    public void TransitionState(StateDef type){
        if(currentState != null){
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
}

public interface IState{    
	//void OnEnter(StateManager manager);
    void OnEnter();
	void OnUpdate();
	void OnExit();
}

public class Idle:IState{

	protected StateManager manager;

    public Idle(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
		
	}

	public virtual void OnUpdate(){

    }

	public virtual void OnExit(){

    }
}

public class ChooseCard:IState{

	protected StateManager manager;

    public ChooseCard(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
        StateManager.Instance.level -= 1;
        if( StateManager.Instance.level == 0){
            Debug.Log("GameOver !");
        }
		//卡牌飛入動畫
        Debug.Log("進入卡牌生成事件");
        //生成5張卡牌
        
        for (int i = 0; i < StateManager.Instance.cardNumber; i++)
        {
            //隨機生成上or下or左or右
            int cardType = Random.Range(0,4); 
            //int cardType = 0;
            CardManager.Instance.CreateCard(cardType);
        }
              
	}

	public virtual void OnUpdate(){
        if(StateManager.Instance.level <= 0 || StateManager.Instance.playerDead ){
            StateManager.Instance.TransitionState(StateDef.end);
        }
        //如果點選卡牌的話           
        if(StateManager.Instance.ButtonClick){
            /*
            if(PlayerManager.Instance.cardType == 0 ){ 
                StateManager.Instance.way = "Forward";           
                StateManager.Instance.TransitionState(StateDef.playerMove);        
            }else if(PlayerManager.Instance.cardType == 1 ){ 
                StateManager.Instance.way = "Back";           
                StateManager.Instance.TransitionState(StateDef.playerMove);           
            }else if(PlayerManager.Instance.cardType == 2 ){ 
                StateManager.Instance.way = "Right";           
                StateManager.Instance.TransitionState(StateDef.playerMove);           
            }else if(PlayerManager.Instance.cardType == 3 ){ 
                StateManager.Instance.way = "Left";           
                StateManager.Instance.TransitionState(StateDef.playerMove);           
            }  
            */
            StateManager.Instance.TransitionState(StateDef.playerMove);                  
        } 
/*
        if(PlayerManager.Instance.triggerType == 1 || PlayerManager.Instance.triggerType == 2 ||PlayerManager.Instance.triggerType == 3 ||PlayerManager.Instance.triggerType == 4||PlayerManager.Instance.triggerType == 5||PlayerManager.Instance.triggerType == 6){
            StateManager.Instance.TransitionState(StateDef.encounter);            
        }   
*/

        if(Player.Instance.triggerType == 1 || Player.Instance.triggerType == 2 ||Player.Instance.triggerType == 3 ||Player.Instance.triggerType == 4||Player.Instance.triggerType == 5||Player.Instance.triggerType == 6){
            StateManager.Instance.TransitionState(StateDef.encounter);            
        } 
    }

	public virtual void OnExit(){
        Debug.Log("離開卡牌生成事件");        
        StateManager.Instance.ButtonClick = false;
        CardManager.Instance.DeleteCard();
        //其他選擇卡牌破壞
        //StateManager.Instance.DestroyCard = true;
    }
}

public class PlayerMove:IState{

	protected StateManager manager;

    public PlayerMove(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
		//角色進行移動
        Debug.Log("進入移動事件");
        //角色移動完成 所以 bool moveComplete = true; 
        /*
        if(!StateManager.Instance.moveComplete){
            if(StateManager.Instance.way == "Forward"){
                PlayerManager.Instance.TurnForward();
                StateManager.Instance.moveComplete = true;
            }else if(StateManager.Instance.way == "Back"){
                PlayerManager.Instance.TurnBack();
                StateManager.Instance.moveComplete = true;
            }else if(StateManager.Instance.way == "Right"){
                PlayerManager.Instance.TurnRight();
                StateManager.Instance.moveComplete = true;
            }else if(StateManager.Instance.way == "Left"){
                PlayerManager.Instance.TurnLeft();
                StateManager.Instance.moveComplete = true;
            }
        } 
        */       
        StateManager.Instance.moveComplete = true;
	}

	public virtual void OnUpdate(){
        if(StateManager.Instance.level <= 0 || StateManager.Instance.playerDead ){
            StateManager.Instance.TransitionState(StateDef.end);
        }
        //如果 moveComplete == true 進行到Encounter State
        if(Player.Instance.triggerType == 1 || Player.Instance.triggerType == 2 ||Player.Instance.triggerType == 3 ||Player.Instance.triggerType == 4||Player.Instance.triggerType == 5||Player.Instance.triggerType == 6){
            StateManager.Instance.TransitionState(StateDef.encounter);            
        }

        if(StateManager.Instance.moveComplete == true){
            Debug.Log("回到選擇卡牌");            
            StateManager.Instance.TransitionState(StateDef.chooseCard);
        }    
    }

	public virtual void OnExit(){
        StateManager.Instance.moveComplete = false;
        Debug.Log("離開移動事件");
        //StateManager.Instance.TransitionState(StateDef.chooseCard);
        //moveComplete = false;
        //StateManager.Instance.moveComplete = false;
    }
}

public class Encounter:IState{

	protected StateManager manager;

    public Encounter(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
        Debug.Log("進入事件");
		//判斷是否有觸發事件
        //如果碰到隨機事件
        if(Player.Instance.triggerType == 1){
            int decreaseHp = Random.Range(15,30);
            Player.Instance.hp -= decreaseHp;
            Player.Instance.atk += Player.Instance.addAtk;
            StateManager.Instance.eventComplete = true;
        }
        //如果碰到寶箱寶劍
        if(Player.Instance.triggerType == 2){            
            Player.Instance.atk += (Player.Instance.addAtk * 3);
            StateManager.Instance.eventComplete = true;
        }
        //如果碰到寶箱盾牌
        if(Player.Instance.triggerType == 3){            
            Player.Instance.def += Player.Instance.addDef;
            StateManager.Instance.eventComplete = true;
        }
        //如果碰到隱藏事件1  
        if(Player.Instance.triggerType == 4){            
            Player.Instance.hp += Player.Instance.addHp;
            StateManager.Instance.eventComplete = true;
        } 
        //如果碰到隱藏事件2  
        if(Player.Instance.triggerType == 5){            
            int decreaseHp = Random.Range(15,30);
            Player.Instance.hp -= decreaseHp;
            StateManager.Instance.eventComplete = true;
        }
        //如果碰到隱藏事件3 尚未做 
        if(Player.Instance.triggerType == 6){   
            StateManager.Instance.eventComplete = true;         
            //int decreaseHp = Random.Range(15,30);
            //PlayerManager.Instance.hp -= decreaseHp;
        }     
	}

	public virtual void OnUpdate(){
        if(StateManager.Instance.level <= 0 || StateManager.Instance.playerDead ){
            StateManager.Instance.TransitionState(StateDef.end);
        }
        //如果事件動畫執行完畢 回到 ChooseCard State
        if(StateManager.Instance.eventComplete){
            Debug.Log("事件回到選擇卡片");
            StateManager.Instance.TransitionState(StateDef.chooseCard);
        }
    }

	public virtual void OnExit(){
        StateManager.Instance.eventComplete = false;
        Player.Instance.triggerType = 0;
    }
}

public class Boss:IState{

	protected StateManager manager;

    public Boss(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
        
	}

	public virtual void OnUpdate(){
        if(StateManager.Instance.level <= 0 || StateManager.Instance.playerDead ){
            StateManager.Instance.TransitionState(StateDef.end);
        }
    }

	public virtual void OnExit(){
        
    }
}

public class End:IState{

	protected StateManager manager;

    public End(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
        Debug.Log("結算畫面");
	}

	public virtual void OnUpdate(){
        
    }

	public virtual void OnExit(){
        
    }
}


/*
[System.Serializeable]
struct StateContainer{
	public StateDef StateDef;
	public State State;
}

public class StateManager :TSingleton<StateManager>{
	private List<StateContainer> rawStates;
	private State currentState;
	private Dictionary<StateDef,State> states;

	private void Awake(){
		
		states = new  Dictionary<StateDef,State>();
		foreach (var pair in rawStates)
		{
			states.Add(pair.StateDef,pair.State);
		}
	}

	private void Update(){
		currentState?.OnUpdate();
	}

	public void ToNextState(string name){
		currentState?.OnExit();
		currentState = states[name];
		currenstate?.OnEnter();
	}
}
*/

/*
public class State:MonoBehaviour,IState{

	protected StateManager Manager;

	public virtual void OnEnter(StateManager manager){
		Manager = manager;
	}
	public abstract void OnUpdate();
	public abstract void OnExit();
}
*/

/*
public class ChooseState:State{
	StateManager manager;
	public override void OnEnter(StateManager manager){
		base.OnEnter(manager);
	}

	public override void OnUpdate(){
		if(Input.GetKeyDown(KeyCode.A)){
			manager.ToNextState("Action");
		}
	}

	public override void OnExit(){

	}
}


public class ActionState:State{
	StateManager manager;
	public override void OnEnter(StateManager manager){
		base.OnEnter(manager);
	}

	public override void OnUpdate(){
		if(Input.GetKeyDown(KeyCode.A)){
			manager.ToNextState("Choose");
		}
	}

	public override void OnExit(){

	}
}

*/