using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour{
    [SerializeField]
    private GameObject[] Screens;
    [SerializeField]
    private GameObject Narrator;
    private bool hasTurnedOffNarrator;

    public void Start() {
        Invoke("OpenMenu", 0.001f);
    }

    public void OpenMenu() {
        RestoreSettings();
        SetActiveScreen(0);
    }

    private void Update() {
        if (!hasTurnedOffNarrator && !Narrator.GetComponent<Toggle>().isOn) {
            Debug.Log("run");
            try {
                GameObject.Find("PlayerCharacter").GetComponent<NarrateL1>().ShowMessage("This is my restaurant. I'm not leaving.");
            } catch (NullReferenceException e) {
                //GameObject.Find("PlayerCharacter").GetComponent<NarrateL2>().ShowMessage("This is my restaurant. I'm not leaving.");
            }
            hasTurnedOffNarrator = true;
        }
    }

    public void SetActiveScreen(int id){
        for(int i=0; i<8; i++){
            Screens[i].SetActive(i == id);
        }
    }

    public void RestoreSettings() {
        GameObject.Find("VSync").GetComponent<Toggle>().isOn = Settings.GetBool("VSync");
        GameObject.Find("VBO").GetComponent<Toggle>().isOn = Settings.GetBool("VBO");
        GameObject.Find("Anaglyph").GetComponent<Toggle>().isOn = Settings.GetBool("Anaglyph");
        GameObject.Find("RTX").GetComponent<Toggle>().isOn = Settings.GetBool("RTX");
        GameObject.Find("Particles").GetComponent<Toggle>().isOn = Settings.GetBool("Particles");
        GameObject.Find("Physics").GetComponent<Toggle>().isOn = Settings.GetBool("Physics");
        GameObject.Find("PPhysics").GetComponent<Toggle>().isOn = Settings.GetBool("PPhysics");
        GameObject.Find("GAccel").GetComponent<Toggle>().isOn = Settings.GetBool("GAccel");
        GameObject.Find("PAccel").GetComponent<Toggle>().isOn = Settings.GetBool("PAccel");
        GameObject.Find("Collisions").GetComponent<Toggle>().isOn = Settings.GetBool("Collisions");
        GameObject.Find("PCollisions").GetComponent<Toggle>().isOn = Settings.GetBool("PCollisions");
        GameObject.Find("Narrator").GetComponent<Toggle>().isOn = Settings.GetBool("Narrator");
        GameObject.Find("Integrity").GetComponent<Toggle>().isOn = Settings.GetBool("Integrity");
        GameObject.Find("Harmonics").GetComponent<Toggle>().isOn = Settings.GetBool("Harmonics");

        GameObject.Find("Mipmaps").GetComponent<Slider>().value = Settings.GetFloat("Mipmaps");
        GameObject.Find("Sounds").GetComponent<Slider>().value = Settings.GetFloat("Sounds");
        GameObject.Find("Music").GetComponent<Slider>().value = Settings.GetFloat("Music");
        GameObject.Find("Variance").GetComponent<Slider>().value = Settings.GetFloat("Variance");
    }

    public void CloseMenu() {
        foreach (GameObject Screen in Screens)
            Screen.SetActive(true);
        SaveSettings();
        SceneManager.UnloadSceneAsync("Menu");
    }

    public void SaveSettings() {
        Settings.SetBool("VSync", GameObject.Find("VSync").GetComponent<Toggle>().isOn);
        Settings.SetBool("VBO", GameObject.Find("VBO").GetComponent<Toggle>().isOn);
        Settings.SetBool("Anaglyph", GameObject.Find("Anaglyph").GetComponent<Toggle>().isOn);
        Settings.SetBool("RTX", GameObject.Find("RTX").GetComponent<Toggle>().isOn);
        Settings.SetBool("Particles", GameObject.Find("Particles").GetComponent<Toggle>().isOn);
        Settings.SetBool("Physics", GameObject.Find("Physics").GetComponent<Toggle>().isOn);
        Settings.SetBool("PPhysics", GameObject.Find("PPhysics").GetComponent<Toggle>().isOn);
        Settings.SetBool("GAccel", GameObject.Find("GAccel").GetComponent<Toggle>().isOn);
        Settings.SetBool("PAccel", GameObject.Find("PAccel").GetComponent<Toggle>().isOn);
        Settings.SetBool("Collisions", GameObject.Find("Collisions").GetComponent<Toggle>().isOn);
        Settings.SetBool("PCollisions", GameObject.Find("PCollisions").GetComponent<Toggle>().isOn);
        Settings.SetBool("Narrator", GameObject.Find("Narrator").GetComponent<Toggle>().isOn);
        Settings.SetBool("Integrity", GameObject.Find("Integrity").GetComponent<Toggle>().isOn);
        Settings.SetBool("Harmonics", GameObject.Find("Harmonics").GetComponent<Toggle>().isOn);

        Settings.SetFloat("Mipmaps", GameObject.Find("Mipmaps").GetComponent<Slider>().value);
        Settings.SetFloat("Sounds", GameObject.Find("Sounds").GetComponent<Slider>().value);
        Settings.SetFloat("Music", GameObject.Find("Music").GetComponent<Slider>().value);
        Settings.SetFloat("Variance", GameObject.Find("Variance").GetComponent<Slider>().value);
    }
}
