using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanstalkManager : MonoBehaviour {

	public GameObject[] beanstalk;
	private Transform playerPos;
	[SerializeField]
	private Transform startPos;
	private float offset = 21.42f;
	private float spawnY = 0f;
	private float safeZone = 80f;
	private float beanstalkLength = 21.42f;
	private int branchLimit = 7;
	private List<GameObject> activeBranches;
	// Use this for initialization
	void Start () {
		spawnY += offset;
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		activeBranches = new List<GameObject>();
		for (int i = 0; i < branchLimit; i++)
		{
			Spawn();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(playerPos.position.y - safeZone > (spawnY - branchLimit * beanstalkLength)){
			Spawn();
			DestroyBranch();
		}
		
	}

	void Spawn(){
		GameObject clone = null;
		clone = Instantiate(beanstalk[0]) as GameObject;
		clone.transform.SetParent(transform);
		clone.transform.position = startPos.position + (Vector3.up*spawnY);
		spawnY += beanstalkLength;
		activeBranches.Add(clone);
	}

	void DestroyBranch(){
		Destroy(activeBranches[0]);
		activeBranches.RemoveAt(0);
	}
}
