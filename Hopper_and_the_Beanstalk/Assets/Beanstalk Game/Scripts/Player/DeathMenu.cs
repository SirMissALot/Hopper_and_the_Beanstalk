using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {


	[SerializeField]
    [Header("GameObject References")]
	private GameObject leafCollected;
	[SerializeField]
	private GameObject leafCount;
	[SerializeField]
	private GameObject joysticks;
	[SerializeField]
	private GameObject count;
	[SerializeField]
	private GameObject replay;
	[SerializeField]
	private Text textCount;
	
	GameObject Player;
	Animator anim;
	private bool Alive;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("CCHopper");
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		Alive = Player.GetComponent<PlayerController>().isAlive;

		if(!Alive){
			anim.SetBool("Dead", true);
		} else{
			textCount.text = GameManager.Instance.Score.ToString();
		}
	}

	// Replay Level
	public void resetGame(){
		SceneManager.LoadScene("Main", LoadSceneMode.Single);
		GameManager.Instance.Score = 0;
	}

	// Death screen
	public void ShowMenu(){
		leafCollected.SetActive(true);
		leafCount.SetActive(true);
		replay.SetActive(true);
	}
	public void HideMenu(){
		leafCollected.SetActive(false);
		leafCount.SetActive(false);
		replay.SetActive(false);
	}

	// Controller UIs
	public void ShowUI(){
		joysticks.SetActive(true);
		count.SetActive(true);
	}
	public void HideUI(){
		joysticks.SetActive(false);
		count.SetActive(false);
	}
}
