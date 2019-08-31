using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrateL2 : MonoBehaviour {
    [SerializeField]
    private Text narrator;
    [SerializeField]
    private BoxCollider2D teaser, secret;
    //Used to track the number of taunt messages
    private int teaseProgress;
    private bool disabledPhysics;

    // Start is called before the first frame update
    void Start() {
        teaseProgress = 0;
        disabledPhysics = false;
        Tease();
    }

    // Update is called once per frame
    void Update() {
        if (!disabledPhysics  && !Settings.GetBool("Physics")) {
            CancelInvoke("ShowMessage");
            CancelInvoke("ClearMessage");
            ShowMessage("Really? You think turning off physics will help?");
            disabledPhysics = true;
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
        if (GetComponent<CircleCollider2D>().IsTouching(teaser)) {
            CancelInvoke("ShowMessage");
            CancelInvoke("ClearMessage");
            ShowMessage("See? There's no exit to the maze. Just go home.");
            teaser.enabled = false;
            Invoke("Tease", 20);
        } else if (GetComponent<CircleCollider2D>().IsTouching(secret)) {
            CancelInvoke("ShowMessage");
            CancelInvoke("ClearMessage");
            if (Settings.GetBool("Physics")) {
                ShowMessage("Oh. You found a secret. So what? You still can't finish the maze.");
                Invoke("Tease", 20);
            } else {
                ShowMessage("Oh. You found a secret.");
            }
            secret.enabled = false;
        }
    }

    private void Tease(){
        switch (teaseProgress) {
            case 0:
                ShowMessage("You should have just left. There's no way out of this maze. It's impossible.");
                Invoke("Tease", 20);
                break;
            case 1:
                ShowMessage("Just leave. It's physically impossible to finish this maze.");
                Invoke("Tease", 40);
                break;
            case 2:
                ShowMessage("You can still look at the menu if you want. Maybe even order something");
                break;
        }
        teaseProgress++;
    }
}
