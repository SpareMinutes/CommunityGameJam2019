using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour{
    [SerializeField]
    private Sprite[] frames;
    [SerializeField]
    private SpriteRenderer icon;
    private int activeFrame;
    private float frameTime;

    private void Start() {
        activeFrame = 0;
        frameTime = 0;
    }

    private void FixedUpdate() {
        frameTime += Time.fixedDeltaTime;
        if (frameTime >= 0.5f) {
            frameTime %= 0.5f;
            activeFrame = (activeFrame + 1) % 2;
            icon.sprite = frames[activeFrame];
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Level_01", LoadSceneMode.Single);
        }
    }
}
