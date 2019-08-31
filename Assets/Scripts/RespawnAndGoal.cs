using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnAndGoal : MonoBehaviour {
    [SerializeField]
    private BoxCollider2D goal, teaser, secret;
    [SerializeField]
    private string nextScene;
    [SerializeField]
    private Vector3 startPos;

    public void Start () {
        startPos = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (GetComponentInParent<CircleCollider2D>().IsTouching(goal)) {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            Debug.Log("goal");
            return;
        }
        if (GetComponentInParent<CircleCollider2D>().IsTouching(teaser) || (SceneManager.GetActiveScene().name.Equals("Maze") && GetComponentInParent<CircleCollider2D>().IsTouching(secret))) {
            Debug.Log("maze");
            return;
        }
            
        //There are no other types of colliders. If this is reached, we can assume it's a respawner.
        //Only check if the player jumped into it or if they fell/got squished
        if(GetComponentInParent<Rigidbody2D>().velocity.y<=0.0001) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //move player back to original position
            gameObject.transform.position = startPos;
            Debug.Log("other");
        }
    }
}
