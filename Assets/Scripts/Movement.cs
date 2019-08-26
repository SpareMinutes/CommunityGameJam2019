using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private float new_x;

    void Update() {
        //get inputs
        new_x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate () {
        //move the gameobject
        gameObject.transform.position += new Vector3 (new_x*speed, gameObject.transform.position.y, gameObject.transform.position.z) * Time.fixedDeltaTime;
    }
}
