using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    public float speed = 200f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Run();
    }

    private void Run()
    {
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.1f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.1f)
        {
            myRigidbody.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime, myRigidbody.velocity.y);
            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }

        if (CrossPlatformInputManager.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1);
        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1);
        }
    }
}
