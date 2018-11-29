using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	[SerializeField]Vector3 offset;
	[SerializeField]float damping;
	Transform cameraLookTarget;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		cameraLookTarget = Player.transform.Find("default");
		if(cameraLookTarget == null){
			cameraLookTarget = Player.transform;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Player.GetComponent<PlayerController>().isAlive){
		Vector3 targetPosition = cameraLookTarget.position + Player.transform.forward * offset.z + 
												   Player.transform.up * offset.y + 
												   Player.transform.right * offset.x;

		Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition,Vector3.up);	

        Vector3 collisionCheckEnd = cameraLookTarget.position;

        Debug.DrawLine(targetPosition,collisionCheckEnd,Color.red);

        RaycastHit hit;
        if(Physics.Linecast(collisionCheckEnd,targetPosition,out hit)){

			Vector3 hitpoints = new Vector3(hit.point.x + hit.normal.x *.2f ,hit.point.y,hit.point.z + hit.normal.z * .2f);
            targetPosition = new Vector3(hitpoints.x,targetPosition.y,hitpoints.z);
        }									   

		transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping);	
		} else {
			transform.position = transform.position;
		}

	}

}

