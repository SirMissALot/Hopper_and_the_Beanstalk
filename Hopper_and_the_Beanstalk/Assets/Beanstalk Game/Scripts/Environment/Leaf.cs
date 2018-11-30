using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {

	[SerializeField]
	private GameObject leaf;
	[SerializeField]
	[Range(0,5)]
	private int timer;
	private Vector3 playerPos;
	void Start () {
		timer = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator LeafCountdown(){
		yield return new WaitForSeconds(timer);
		GameManager.Instance.Score+=1;
		Instantiate(leaf,playerPos,Quaternion.identity);
		Destroy(gameObject);
	}


	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			playerPos = other.transform.position;
			StartCoroutine(LeafCountdown());
		}
	}


}
