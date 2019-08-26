using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, jumpForce, goingDownGravity, goingUpGravity;
    public bool canJump = true;
    private float new_x;
    private Rigidbody2D rb;
    

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        //get inputs
        new_x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            Jump();
        }

        if (rb.velocity.y < 0) {
            //increase gravity for the faster falling
            rb.gravityScale = goingDownGravity;
        } else {
            rb. gravityScale = goingUpGravity;
        }
    }

    void FixedUpdate () {
        //move the gameobject
        gameObject.transform.position += new Vector3 (new_x*speed, gameObject.transform.position.y, gameObject.transform.position.z) * Time.fixedDeltaTime;
    }

    void Jump () {
        rb.AddForce(new Vector3(0,jumpForce,0));
    }

    
}
