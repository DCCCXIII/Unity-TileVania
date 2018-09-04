using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    //Config
    [SerializeField] float speed = 2f;
    [SerializeField] float jump = 2f;
    [SerializeField] float climbSpeed = 2;

    // State
    public bool isAlive = true;
    public bool isGrounded;

    // Component references
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private Collider2D myCollider;
    private Collider2D feetCollider;
    float horizontalInput;
    float verticalInput;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<CapsuleCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        Run();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        bool isMovingHorizontaly = horizontalInput < -0.1f || horizontalInput > 0.1f;

        myRigidbody.velocity = new Vector2(horizontalInput * speed, myRigidbody.velocity.y);

        // Moves player character left or right
        if (isMovingHorizontaly)
        {
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
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, +jump);
        }
    }

    private void ClimbLadder()
    {

        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = 1;
            myAnimator.SetBool("Climbing", false);
            return;
        }

        myRigidbody.velocity = new Vector2(horizontalInput * speed, verticalInput * climbSpeed);
        myRigidbody.gravityScale = 0;
        myAnimator.SetBool("Climbing", true);

    }
    
}
