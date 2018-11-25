using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class FallingLeaf : MonoBehaviour {

	[SerializeField]
	[Range(3,5)]
	private int timer;

	// Use this for initialization
	void Start () {
		timer = 3;
		StartCoroutine(DestroySelf());
	}
	
	IEnumerator DestroySelf(){
		yield return new WaitForSeconds(timer);
		Destroy(gameObject);
	}
		
}
