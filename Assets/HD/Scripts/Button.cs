using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {


	public void ForwardOnClick(){
		Player.Instance.TurnForward();
	}

    public void BackOnClick(){
		Player.Instance.TurnBack();
	}

    public void RightOnClick(){
		Player.Instance.TurnRight();
	}

    public void LeftOnClick(){
		Player.Instance.TurnLeft();
	}
}