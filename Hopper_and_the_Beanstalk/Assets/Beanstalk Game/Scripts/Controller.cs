using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float fowardVel = 12;
	public float rotateVel = 100;
	public float jumpForce = 25;
	public float distanceToGrounded = 0.1f;
	public LayerMask ground;
	public float gravity = 0.75f;
	public VirtualJoystick joystick;
	Animator m_anim;
	Quaternion targetRotation;
	Rigidbody rBody;
	Vector3 velocity = Vector3.zero;
	float forwardInput, turnInput, jumpInput;
	public Quaternion TargetRotation{ get{ return targetRotation; }}
	bool Grounded(){
		return Physics.Raycast(transform.position,Vector3.down,distanceToGrounded,ground);
	}
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		rBody = GetComponent<Rigidbody>();
		m_anim = GetComponent<Animator>();

		forwardInput = turnInput = jumpInput = 0;
	}

	void GetInput(){
		forwardInput = joystick.Vertical();
		turnInput = joystick.Horizontal();
		jumpInput = Input.GetAxisRaw("Jump");

		m_anim.SetFloat("VelX", forwardInput);
		m_anim.SetFloat("VelY", turnInput);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		Turn();
	}

	void FixedUpdate (){
		Move();
		Jump();

		rBody.velocity = transform.TransformDirection(velocity);
	}

	void Move(){
		if(Mathf.Abs(forwardInput) > inputDelay){
			// rBody.velocity = transform.forward * forwardInput * fowardVel;
			velocity.z = fowardVel * forwardInput;
		} else {
			// rBody.velocity = Vector3.zero;
			velocity.z = 0;
		}
	}

	void Turn(){

		if(Mathf.Abs(turnInput) > inputDelay){
			targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}

	void Jump(){
		if(jumpInput> 0 && Grounded()){
			velocity.y = jumpForce;
			m_anim.SetBool("Jump", true);
		}
		else if(jumpInput == 0 && Grounded()){
			velocity.y = 0;
			m_anim.SetBool("Jump", false);
		}
		else{
			velocity.y -= gravity;
		}
	}

		
}
