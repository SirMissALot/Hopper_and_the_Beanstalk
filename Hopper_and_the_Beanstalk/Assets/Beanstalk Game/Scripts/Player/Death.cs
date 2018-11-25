using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject Player;

	public Vector3 offset = new Vector3(0,-1f,0);

	public bool stay;
	

	// Use this for initialization
	void Start () {
		stay = Player.GetComponent<PlayerController>().isGrounded;
	}
	
	// Update is called once per frame
	void Update () {
		stay = Player.GetComponent<PlayerController>().isGrounded;
	}

	void LateUpdate(){
		if(stay){
			transform.position = Player.transform.position+offset;
		} else{
			transform.position = transform.position;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Debug.Log("Dead!");
		}
	}
}
 