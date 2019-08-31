using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    AudioSource audioData;

    void Start() {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        Debug.Log("started playing music");
    }
}
