
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;

public enum StateDef
{
    idle,
	chooseCard,
	playerMove,
    encounter
}

public class StateManager : TSingletonMonoBehavior<StateManager>{
    //判斷是否有按按鈕
    public bool ButtonClick = false;
    //判斷玩家是否完成移動
    public bool moveComplete = false;
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
        states.Add(StateDef. encounter, new Encounter(this));
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
		//卡牌飛入動畫
        Debug.Log("進入卡牌生成事件");
        //生成5張卡牌
        
        for (int i = 0; i < StateManager.Instance.cardNumber; i++)
        {
            //隨機生成上or下or左or右
            int cardType = Random.Range(0,3);   
            CardManager.Instance.CreateCard(cardType);
        }
              
	}

	public virtual void OnUpdate(){
        //如果點選卡牌的話           
        if(StateManager.Instance.ButtonClick){
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
        }    
              
    }

	public virtual void OnExit(){
        //其他選擇卡牌破壞
    }
}

public class PlayerMove:IState{

	protected StateManager manager;

    public PlayerMove(StateManager manager){
        this.manager = manager;
    } 

	public virtual void OnEnter(){
		//角色進行移動
        Debug.Log("進入角色移動事件");
        //角色移動完成 所以 bool moveComplete = true; 
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
        
	}

	public virtual void OnUpdate(){
        //如果 moveComplete == true 進行到Encounter State
        if(PlayerManager.Instance.triggerEnemy == true){
            StateManager.Instance.TransitionState(StateDef.encounter);
            
        }
    }

	public virtual void OnExit(){
        //moveComplete = false;
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

        //如果碰到敵人遭遇戰

        //如果碰到寶箱        
	}

	public virtual void OnUpdate(){
        //如果事件動畫執行完畢 回到 ChooseCard State
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