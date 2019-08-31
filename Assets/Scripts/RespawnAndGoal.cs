using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnAndGoal : MonoBehaviour {
    [SerializeField]
    private BoxCollider2D goal, teaser  ;
    [SerializeField]
    private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (GetComponentInParent<CircleCollider2D>().IsTouching(goal))
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        if (GetComponentInParent<CircleCollider2D>().IsTouching(teaser))
            return;
        //There are no other types of colliders. If this is reached, we can assume it's a respawner.
        //Only check if the player is on the ground.
        if(GetComponentInParent<Movement>().CanJump())
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
