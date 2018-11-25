using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanstalkCreation : MonoBehaviour {

	public Transform beanstalkbase;
	public GameObject beanstalk;
	Vector3 offset = new Vector3(0,23.3f,0);

	// Use this for initialization
	void Start () {
		GameObject clone = Instantiate(beanstalk,beanstalkbase.position+offset,Quaternion.identity);
		clone.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
