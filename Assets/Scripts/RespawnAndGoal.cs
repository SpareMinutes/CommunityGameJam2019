using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnAndGoal : MonoBehaviour {
    [SerializeField]
    private BoxCollider2D respawner, goal;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("run");
        if(GetComponentInParent<CircleCollider2D>().IsTouching(respawner))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
