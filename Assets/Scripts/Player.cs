using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    //Config
    [SerializeField] float speed = 2f;
    [SerializeField] float jump = 2f;

    // State
    public bool isAlive = true;

    // Component references
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
        Jump();
    }

    private void Run()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        bool isMovingHorizontaly = horizontalInput < -0.1f || horizontalInput > 0.1f;

        // Moves player character left or right
        if (isMovingHorizontaly)
        {
            myRigidbody.velocity = new Vector2(horizontalInput * speed, myRigidbody.velocity.y);
            myAnimator.SetBool("Running", true);

            // Flips sprite on the direction of movement
            transform.localScale = new Vector3(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, +jump);
        }
    }
}
