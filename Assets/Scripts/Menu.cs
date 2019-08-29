using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{
    [SerializeField]
    private GameObject[] Screens;

    public void Start() {
        Invoke("OpenMenu", 0.001f);
    }

    public void OpenMenu() {
        RestoreSettings();
        SetActiveScreen(0);
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
        SceneManager.UnloadSceneAsync("Menu");
    }
}
