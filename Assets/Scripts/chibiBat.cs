using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chibiBat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	//Update is called once per frame
	void Update () {
		
	}

	public void changeDirection(string direction)
	{ if (direction == "LEFT") {
			transform.localPosition = new Vector3 (transform.localPosition.x-2.82f, transform.localPosition.y-4.73f, transform.position.z);}
	else if(direction== "RIGHT"){
		transform.localPosition = new Vector3 (transform.localPosition.x+2.82f, transform.localPosition.y+4.73f, transform.position.z);
	}	

	}
}
