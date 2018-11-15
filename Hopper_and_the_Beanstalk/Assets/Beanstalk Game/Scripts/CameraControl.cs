using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offset = new Vector3(0,6,-8);
	public float xTilt = 10f;
	Vector3 destination = Vector3.zero;
	Controller m_controller;
	float rotateVel = 0;

	// Use this for initialization
	void Start () {
		SetCameraTarget(target);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetCameraTarget(Transform t){
		target = t;

		m_controller = target.GetComponent<Controller>();
	}

	void LateUpdate(){

		MoveToTarget();
		LookAtTarget();
	}

	void MoveToTarget(){
		destination = m_controller.TargetRotation * offset;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget(){
		float eulerYAngle = Mathf.SmoothDamp(transform.eulerAngles.y,target.eulerAngles.y,ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x,eulerYAngle,0);
	}

	 
}
