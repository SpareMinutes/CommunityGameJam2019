using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour{

    public static bool GetBool(string name){
        return PersistentVariables.Bools[name];
    }

    public static float GetFloat(string name){
        return PersistentVariables.Floats[name];
    }

    public void ToggleBool(string name){
        PersistentVariables.Bools[name] = !PersistentVariables.Bools[name];
    }

    public void UpdateFloat(string name){
        PersistentVariables.Floats[name] = GameObject.Find(name).GetComponent<Slider>().value;
    }
}