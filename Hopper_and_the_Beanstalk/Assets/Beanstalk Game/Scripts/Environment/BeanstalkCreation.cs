using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanstalkCreation : MonoBehaviour {

	public GameObject beanstalkbase;
	public GameObject beanstalkbranch;
	Vector3 offset = new Vector3(0,23.31f,0);
	Vector3 offset2 = new Vector3(0,21.42f,0);
	private int beanstalkCount = 20;
	
	// Use this for initialization
	// 44.7 , 66.1 , 87.5 ,44.73 , 21.42
	void Start () {
			
		GameObject clone = null;

		clone = Instantiate(beanstalkbranch, beanstalkbase.transform.position + offset, Quaternion.identity);
		clone.transform.parent = transform;

		// clone = Instantiate(beanstalkbranch, beanstalkbase.transform.position + offset2, Quaternion.identity);
		// clone.transform.parent = transform;

		for (int i = 2; i < beanstalkCount; i++)
		{	
			clone = Instantiate(beanstalkbranch, beanstalkbase.transform.position + (offset2*i) , Quaternion.identity);
			clone.transform.parent = transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
