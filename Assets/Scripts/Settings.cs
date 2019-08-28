using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour{
    private static Settings Instance;
    private Dictionary<string, bool> Bools;
    private Dictionary<string, float> Floats;

    public void Start(){
            Instance = new Settings(
                new Dictionary<string, bool>{
                    {"VSync", false},
                    {"VBO", false},
                    {"Anaglyph", false},
                    {"RTX", false},
                    {"Particles", true},
                    {"Physics", true},
                    {"PPhysics", true},
                    {"GAccel", true},
                    {"PAccel", true},
                    {"Collisions", true},
                    {"PCollisions", true},
                    {"Narrator", false},
                    {"Variance", false},
                    {"Harmonics", false}
                },
                new Dictionary<string, float>{
                    {"Mipmaps", 1},
                    {"Sounds", 1},
                    {"Music", 1}
                }
            );
    }

    private Settings(Dictionary<string, bool> b, Dictionary<string, float> f){
        this.Bools = b;
        this.Floats = f;
    }

    public static bool GetBool(string name){
        return Instance.Bools[name];
    }

    public static float GetFloat(string name){
        return Instance.Floats[name];
    }

    public void ToggleBool(string name){
        Instance.Bools[name] = !Instance.Bools[name];
    }

    public void UpdateFloat(string name){
        Instance.Floats[name] = GameObject.Find(name).GetComponent<Slider>().value;
    }
}