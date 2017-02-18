using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	Animator anim;
	float upMag, sideMag;
    bool one_click = false;
    float timer_for_double_click;
    //this is how long in seconds to allow for a double click
    float delay = 0.25f;
    int taps = 0;

    // Use this for initialization
    void Start () {
		upMag = 200f;
		sideMag = 400f;

		anim = GetComponent<Animator> ();
	}

    // Update is called once per frame
    void Update()
    {

//        if (isTouchingPlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!one_click) // first click no previous clicks
                {
                    one_click = true;
                    timer_for_double_click = Time.time; // save the current time
                }
                else
                {
                    one_click = false; // found a double click, now reset

                    //do double click stuff here
                    taps = 2;
                    singleOrDouble(taps);                    
                    Debug.Log("Double Click");
                }
            }
            if (one_click)
            {
                // if the time now is delay seconds more than when the first click started. 
                if ((Time.time - timer_for_double_click) > delay)
                {
                    //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.
                    one_click = false;
                    // do single click stuff;
                    taps = 1;
                    singleOrDouble(taps);
                    Debug.Log("Single Click");
                }
            }
        }

    }


    void singleOrDouble(int tapCount)
    {
        if (tapCount > 0)
		{ int direction=1;
			if (Input.mousePosition.x > Screen.width / 2)
			    direction = 1; //to indicate right;
				anim.SetInteger("State",1);	
			
			if (Input.mousePosition.x < Screen.width / 2)
			    direction = -1; //to indicate left

            Camera.main.transform.Translate(Vector3.up * Time.deltaTime * upMag);
            transform.Translate(Vector3.up *  Time.deltaTime * upMag);
            transform.Translate(Vector3.right * direction * Time.deltaTime * sideMag * tapCount);
            taps = 0;
        }
    }
    
}