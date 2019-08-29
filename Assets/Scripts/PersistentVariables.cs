using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentVariables {

    public static  Dictionary<string, bool> Bools = new Dictionary<string, bool>{
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
                    {"Integrity", false},
                    {"Harmonics", false}
                };

public static Dictionary<string, float> Floats = new Dictionary<string, float> {
                    {"Mipmaps", 1},
                    {"Sounds", 1},
                    {"Music", 1},
                    {"Variance", 1}
                };

}
