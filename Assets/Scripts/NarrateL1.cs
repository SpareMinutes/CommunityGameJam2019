using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrateL1 : MonoBehaviour{
    [SerializeField]
    private Text narrator;
    [SerializeField]
    private BoxCollider2D teaser;
    //Used to track the number of taunt messages
    private int teaseProgress;
    private bool enabledPlatform;

    // Start is called before the first frame update
    void Start(){
        ShowMessage("Oh. You shouldn't be here. The game isn't finished yet.");
        teaseProgress = 0;
        enabledPlatform = false;
    }

    // Update is called once per frame
    void Update(){
        if (!enabledPlatform && teaseProgress>0 && Settings.GetBool("Integrity")){
            CancelInvoke("ShowMessage");
            CancelInvoke("ClearMessage");
            ShowMessage("Oh. You fixed it.");
            enabledPlatform = true;
        }
    }

    public void ShowMessage(string msg) {
        narrator.text = msg;
        Invoke("ClearMessage", 5);
    }

    public void ClearMessage() {
        narrator.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (GetComponent<CircleCollider2D>().IsTouching(teaser) && !Settings.GetBool("Integrity")) {
            Tease();
            teaser.enabled = false;
        }
    }

    private void Tease() {
        switch (teaseProgress) {
            case 0:
                ShowMessage("See? The lift is broken. No way to finish. You can go now.");
                Invoke("Tease", 20);
                break;
            case 1:
                ShowMessage("If you're going to stay, at least order food. Would you like a menu?");
                Invoke("Tease", 25);
                break;
            case 2:
                ShowMessage("It's not going to move. Its structure is too weak. There's no way to fix it.");
                break;
        }
        teaseProgress++;

    }
}
