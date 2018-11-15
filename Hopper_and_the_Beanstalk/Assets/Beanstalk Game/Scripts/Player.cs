using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed = 5.0f;
	private float drag = 0.5f;
	private float rotateSpeed = 25.0f;
	private Vector3 movement;
	private Vector3 rot;
	public VirtualJoystick joystick;
	Rigidbody m_rdby;
	Animator animator;


	// Use this for initialization
	void Start () {
		m_rdby = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		rot = new Vector3(0,100,0);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			m_rdby.AddForce(Vector3.up * 5f, ForceMode.Impulse);
		}

		

		movement = new Vector3(0 ,0, joystick.Vertical()* speed *Time.deltaTime);
	}

	void FixedUpdate(){
		
		Quaternion deltaRotation = Quaternion.Euler(rot * Time.deltaTime);
        m_rdby.MoveRotation(m_rdby.rotation * deltaRotation);
		m_rdby.MovePosition(m_rdby.position + movement);
		
		
	}

	
	private Vector3 CharaDirection(){

		Vector3 dir = Vector3.zero;

		dir.x = joystick.Horizontal();
		dir.z = joystick.Vertical();

		if(dir.magnitude > 1){
			dir.Normalize();
		}

		return dir;

	}
}
