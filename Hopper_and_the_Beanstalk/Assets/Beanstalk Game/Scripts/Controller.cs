using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float fowardVel = 12;
	public float rotateVel = 100;
	public float jumpForce = 25;
	public bool isGrounded;
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
		isGrounded = true;


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

	// Input Check
	void GetInput(){
		
		forwardInput = joystick.Vertical();
		turnInput = joystick.Horizontal();
		jumpInput = Input.GetAxisRaw("Jump");

		m_anim.SetFloat("VelX", forwardInput);
		m_anim.SetFloat("VelY", turnInput);
	}

	// Movement + Turn Input
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

	// Jump Input
	void Jump(){
		if(jumpInput> 0 && isGrounded && !m_anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")){
			velocity.y = jumpForce;
			m_anim.SetBool("Jump", true);
		}
		else if(jumpInput == 0 && isGrounded){
			velocity.y = 0;
			m_anim.SetBool("Jump", false);
		}
		else{
			velocity.y -= gravity;
			
		}
	}

	// Ground check
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Ground"){
			isGrounded = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Ground"){
			isGrounded = false;
		}
	}

	

		
}
