using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public string direction; // horiztonal / vertical
    public float speed; 
    public float distance; //make negative to go in the opposite direction

    private Vector3 startPos; //the origin position

    public void Start () {
        startPos = gameObject.transform.position;
    }
    
    public void FixedUpdate () {
        float currentDistance = Vector3.Distance(startPos, gameObject.transform.position);
        if (currentDistance >= distance) {
                //then the platform has reached the end of its path and the speed should be reversed
                speed *= -1;
        }

        if (direction.Equals("vertical")) {
            //move the platform in the y direction by the distance
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);

        } else if (direction.Equals("horizontal")) {
            //move the platform in the x direction by the distance
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);

        } else {
            Debug.Log("not a valid direction");
        }
    }
}
