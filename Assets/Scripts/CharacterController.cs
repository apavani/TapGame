using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    Animator anim;
	public float xoffset, yoffset;
    float upMag, sideMag;
    bool one_click = false;
    float timer_for_double_click;
    //this is how long in seconds to allow for a double click
    float delay = 0.25f;
    int taps = 0;
    private bool isTransitioning;
    private MovementData mData = new MovementData();
    // Use this for initialization
    void Start() {
        upMag = 2f;
        sideMag = 4f;
		xoffset = 5.3334f;
		yoffset = 5.73f;

        anim = GetComponent<Animator>();
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
        if (isTransitioning) //previously triggered co routine is still in progress
            return;
        mData.tapCount = tapCount;

        if (tapCount > 0)
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                mData.target = new Vector3(transform.position.x+xoffset*tapCount, transform.position.y+yoffset);
                StopCoroutine("MoveNext");
                StartCoroutine("MoveNext");
            }
            if (Input.mousePosition.x < Screen.width / 2)
            {
                mData.target = new Vector3(transform.position.x-xoffset*tapCount, transform.position.y+yoffset);
                StopCoroutine("MoveNext");
                StartCoroutine("MoveNext");
            }

            //Camera.main.transform.Translate(Vector3.up * Time.deltaTime * upMag);
        }
    }

    private IEnumerator MoveNext()
    {
        this.isTransitioning = true;
        //first finish animation
        anim.SetInteger("State", 1);
        while (anim.GetAnimatorTransitionInfo(0).IsName("left"))
            yield return null;

        //set animation back to idle


        //move the character
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(transform.position, mData.target);
        Vector3 startPosition = transform.position;
        Vector3 cameraStart = Camera.main.transform.position;
        float speed = 15f*mData.tapCount;
        while (transform.position.y < mData.target.y)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, mData.target, fracJourney);
            float deltaCharacter = transform.position.y - startPosition.y;
            Camera.main.transform.position = new Vector3(cameraStart.x, cameraStart.y+deltaCharacter, cameraStart.z);
            yield return null;
        }
        anim.SetInteger("State", 0);
        this.isTransitioning = false;
    }
}

public class MovementData
{
    public Vector3 target;
    public int tapCount;
    public int direction;
}