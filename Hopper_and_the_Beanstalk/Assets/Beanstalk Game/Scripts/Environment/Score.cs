using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	private GameObject Player;
	private int score;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("CCHopper");
	}
	
	// Update is called once per frame
	void Update () {
		if((int)Player.transform.position.y > score){
			score = (int)Player.transform.position.y;
			score *= 10;
			score -=170;
			Debug.Log(score);
		} else{
			Debug.Log(score);
		}
	}
}
