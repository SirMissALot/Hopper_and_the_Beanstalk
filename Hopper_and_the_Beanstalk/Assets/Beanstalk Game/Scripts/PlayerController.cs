using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
	public VirtualJoystick joystick;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
	private Animator m_anim;
	float forwardInput, turnInput, jumpInput;

    void Start()
    {	
		m_anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>(); 
		forwardInput = turnInput = 0;
		
    
    }

    void Update()
    {
		GetInput();
		Debug.Log(forwardInput);
		Debug.Log(turnInput);

        if (controller.isGrounded)
        {
			m_anim.SetBool("Jump", false);
            // We are grounded, so recalculate
            // move direction directly from axes
		
            moveDirection = new Vector3(0, 0.0f, forwardInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
				m_anim.SetBool("Jump", true);
            }
        }
		
        // Apply gravity
		transform.Rotate(0,turnInput,0);
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
		
    }

	void GetInput(){
		forwardInput = joystick.Vertical();
		turnInput = joystick.Horizontal();
		m_anim.SetFloat("VelX", forwardInput);
		m_anim.SetFloat("VelY", turnInput);
	}

	
}
