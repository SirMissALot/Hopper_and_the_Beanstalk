using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

	private float speed;
	private float rotateSpeed = 200f;
	private float jumpForce = 7f;
	public VirtualJoystick joystick;
	Rigidbody radbody;

	void Start(){
		speed = 0.1f;
		radbody = GetComponent<Rigidbody>();
	}

	void Update(){

		

		Move(joystick.Vertical(),joystick.Horizontal());

		if(Input.GetKeyDown(KeyCode.Space)){
			radbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

	}

	void Move(float moveInput, float rotateInput){

		MoveInput(moveInput);
		TurnInput(rotateInput);
	}
	
	void MoveInput(float input){

		transform.Translate(Vector3.forward * input * speed);
	}

	void TurnInput(float input){

		transform.Rotate(0, input * rotateSpeed * Time.deltaTime, 0);
	}
	
}
