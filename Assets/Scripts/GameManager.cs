using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] branchPrefabs;

	// Use this for initialization
	void Start () {
		            for(int i = 0; i<10; i+=2)	
	          {
		         GameObject trunkempty = Instantiate (branchPrefabs [1]);
		         trunkempty.transform.parent = gameObject.transform;
			     trunkempty.transform.localPosition = new Vector3(0f, i*10f, 0f);

			     GameObject trunkempty_ = Instantiate (getrandombranch());
		         trunkempty_.transform.parent = gameObject.transform;
			     trunkempty_.transform.localPosition = new Vector3(0f, (i+1)*10f, 0f);
	           }
	               }
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject getrandombranch()
	{
		int random = Random.Range (0, 250);

		if (random <= 50) {
			return branchPrefabs [1];
		}		

		return branchPrefabs [0];

	}
}
