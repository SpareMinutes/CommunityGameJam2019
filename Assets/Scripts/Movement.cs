using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour{
    public float speed, jumpForce;
    public AudioClip sound;

    private Rigidbody2D rb;
    private float x;
    

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

        if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name.Equals("Level_01"))
                GameObject.Find("PlayerCharacter").GetComponent<NarrateL1>().ShowMessage("Don't bother with the settings. They're broken.");
            else if (SceneManager.GetActiveScene().name.Equals("Maze"))
                GameObject.Find("PlayerCharacter").GetComponent<NarrateL2>().ShowMessage("Don't bother with the settings. They're broken.");
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
        GetComponentInParent<AudioSource>().mute = false;
        rb.AddForce(new Vector3(0,jumpForce,0));
        GetComponentInParent<AudioSource>().Play();
    }

    public bool CanJump() {
        //return true;
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        CircleCollider2D collider = rb.GetComponent<CircleCollider2D>();
        int count = collider.GetContacts(contacts);
        if (SceneManager.GetActiveScene().name.Equals("Maze") && !Settings.GetBool("Physics"))
            return true;
        for (int i = 0; i < 10; i++) {
            float dx = collider.bounds.center.x - contacts[i].point.x;
            float dy = collider.bounds.center.y - contacts[i].point.y;
            if (dy > 0 && dy >= Mathf.Abs(dx) && i < count) {
                return true;
            }
        }
        return false;
    }
}
