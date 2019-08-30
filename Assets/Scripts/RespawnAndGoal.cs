using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnAndGoal : MonoBehaviour {
    [SerializeField]
    private BoxCollider2D respawner, goal;
    [SerializeField]
    private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(GetComponentInParent<CircleCollider2D>().IsTouching(respawner))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (GetComponentInParent<CircleCollider2D>().IsTouching(goal))
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
