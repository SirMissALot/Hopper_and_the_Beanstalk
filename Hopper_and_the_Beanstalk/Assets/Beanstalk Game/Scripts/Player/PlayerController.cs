using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    [Header("PLAYER STATUS")]
	private float speed = 6.0f;
    [SerializeField]
    private float jumpSpeed = 8.0f;
    [SerializeField]
    private float gravity = 20.0f;
    [SerializeField]
    [Header("JOYSTICK REFERENCE")]
	public VirtualJoystick joystick;

    // Private Variables
    private Animator m_anim;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
	private float forwardInput, turnInput, jumpInput;
    private bool Grounded, Alive;

    // Getter
    public bool isGrounded{get{return Grounded;}}
    public bool isAlive{get{return Alive;}}

    void Start()
    {	
		m_anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>(); 
		forwardInput = turnInput = 0;
        Alive = true;
        Grounded = controller.isGrounded;
    }

    void Update()
    {
		GetInput();

		Grounded = controller.isGrounded;

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

		
        // Turn Input
		transform.Rotate(0,turnInput,0);
        // Apply gravity
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
