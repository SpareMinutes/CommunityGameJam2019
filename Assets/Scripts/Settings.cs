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

    public static void SetBool(string name, bool value){
        PersistentVariables.Bools[name] = value;
    }

    public static void SetFloat(string name, float value){
        PersistentVariables.Floats[name] = value;
    }
}