using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    public float speed, jumpForce;
    private Rigidbody2D rb;
    

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        //get inputs
        float x = Input.GetAxisRaw("Horizontal");

        //Eliminate rotation inertia when touching something but not moving
        rb.constraints = (x==0&&rb.GetContacts(new ContactPoint2D[10])!=0) ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.None;

        //Move the player
        rb.velocity = new Vector3(x*speed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
            Jump();
        }
    }

    void Jump () {
        rb.AddForce(new Vector3(0,jumpForce,0));
    }

    bool CanJump(){
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        CircleCollider2D collider = rb.GetComponent<CircleCollider2D>();
        int count = collider.GetContacts(contacts);
        for (int i = 0; i < 10; i++){
            float dx = collider.bounds.center.x - contacts[i].point.x;
            float dy = collider.bounds.center.y - contacts[i].point.y;
            if (dy > 0 && dy >= Mathf.Abs(dx) && i < count){
                return true;
            }
        }
        return false;
    }
}
