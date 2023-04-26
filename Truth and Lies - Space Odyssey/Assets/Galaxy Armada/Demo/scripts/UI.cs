using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UI : MonoBehaviour {

	public Slider Shield;
	public Text points;
	public GameObject GameOvertext;
	public GameObject StartButton;
	public GameObject RestartButton;
	private int totalPoints=0;
	public static UI instance;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	public void GameRun(){
		if(GameOvertext.activeSelf)	GameOvertext.SetActive (false);
		if(StartButton.activeSelf)	StartButton.SetActive (false);
		if(RestartButton.activeSelf) RestartButton.SetActive (false);
	}

	public void FirstRun(){
		if(GameOvertext.activeSelf)	GameOvertext.SetActive (false);
		if(!StartButton.activeSelf)	StartButton.SetActive (true);
		if(RestartButton.activeSelf) RestartButton.SetActive (false);
	}

	public void GameOver(){
		if(!GameOvertext.activeSelf)	GameOvertext.SetActive (true);
		if(StartButton.activeSelf)	StartButton.SetActive (false);
		if(!RestartButton.activeSelf) RestartButton.SetActive (true);
	}

	public void setupShield(int _amount){
		Shield.maxValue = _amount;
		Shield.value = _amount;
	}

	public void UpdateShield(int _shield){
		Shield.value = _shield;
	}

	public void UpdatePoints(int _amount){
		totalPoints += _amount;
		points.text = totalPoints.ToString ();
	}
}
