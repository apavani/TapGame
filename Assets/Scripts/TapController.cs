using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour {

	private string direction;
	public chibiBat chibibat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Tap(string tap){
		chibibat.changeDirection (tap);
	}
}
