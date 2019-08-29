using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour{
    public float speed, jumpForce;
    
    private Rigidbody2D rb;
    private float x;
    private bool canJump;
    

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(SceneManager.sceneCount != 1)
            return;
        //get inputs
        x = Input.GetAxisRaw("Horizontal");

        //Eliminate rotation inertia when touching something but not moving
        rb.constraints = (x==0&&rb.GetContacts(new ContactPoint2D[10])!=0) ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.None;


        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
    }

    void FixedUpdate () {
        //Move the player
        rb.velocity = new Vector3(x*speed, Mathf.Min(rb.velocity.y, 15), 0);

        //makes the jumping a little less floaty
        if (rb.velocity.y < 0) {
            rb.gravityScale = 2;
        } else {
            rb.gravityScale = 1;
        }
    }

    void Jump () {
        rb.AddForce(new Vector3(0,jumpForce,0));
    }

    void OnCollisionEnter2D (Collision2D other) {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            canJump = true;
        }
    }

    void OnCollisionExit2D (Collision2D other) {
        canJump = false;
    }
}
