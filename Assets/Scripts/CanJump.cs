using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter2D () {
        Player.GetComponent<Movement>().canJump = true;
    }

    void OnTriggerExit2D () {
        Player.GetComponent<Movement>().canJump = false;
    }
}
