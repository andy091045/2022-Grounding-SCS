using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class Button : MonoBehaviour {

    AudioSource audio;

    private void Start() {
        audio = GetComponent<AudioSource>();
    }
	public void ForwardOnClick(){
        audio.Play(0);
		Player.Instance.TurnForward();
	}

    public void BackOnClick(){
        audio.Play(0);
		Player.Instance.TurnBack();
	}

    public void RightOnClick(){
        audio.Play(0);
		Player.Instance.TurnRight();
	}

    public void LeftOnClick(){
        audio.Play(0);
		Player.Instance.TurnLeft();
	}
}