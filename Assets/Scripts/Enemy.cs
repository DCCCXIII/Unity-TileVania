using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 1.0f;

    public bool isMovingLeft = false;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Collider2D sidesCollider;

	// Use this for initialization
	void Start () {
        myCollider = GetComponent<CircleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sidesCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        ToggleIsMovingLeft();
    }

    private void Move()
    {
        if (!isMovingLeft)
        {
            myRigidbody.velocity = new Vector2(speed * Time.deltaTime, myRigidbody.velocity.y);
        } else if (isMovingLeft)
        {
            myRigidbody.velocity = new Vector2(speed * Time.deltaTime * -1, myRigidbody.velocity.y);
        }

    }

    private void ToggleIsMovingLeft()
    {
        if (sidesCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (isMovingLeft)
            {
                isMovingLeft = false;
            } else if (!isMovingLeft)
            {
                isMovingLeft = true;
            }
        }
    }
}
