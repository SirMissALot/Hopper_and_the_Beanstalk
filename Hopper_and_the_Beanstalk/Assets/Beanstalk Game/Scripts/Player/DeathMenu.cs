using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {


	[SerializeField]
    [Header("GameObject References")]
	private GameObject leafCollected;
	[SerializeField]
	private GameObject leafCount;
	[SerializeField]
	private GameObject joysticks;
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
			anim.SetTrigger("FadeIn");
		} else{
			textCount.text = GameManager.Instance.Score.ToString();
		}
	}

	public void ShowMenu(){
		leafCollected.SetActive(true);
		leafCount.SetActive(true);
		joysticks.SetActive(false);
	}
	public void HideMenu(){
		leafCollected.SetActive(false);
		leafCount.SetActive(false);
		joysticks.SetActive(true);
	}
}
