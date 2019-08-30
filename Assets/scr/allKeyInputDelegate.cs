using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class allKeyInputDelegate : MonoBehaviour
{
    Dictionary<KeyCode, Action> keyDictionary;
    private string state;
    // Start is called before the first frame update
    void Start()
    {        
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.A, KeyDown_A },
            { KeyCode.S, KeyDown_S },
            { KeyCode.D, KeyDown_D },
            { KeyCode.W, KeyDown_W },
            { KeyCode.Space, KeyDown_Space },
            { KeyCode.C, KeyDown_C },
            { KeyCode.Q, KeyDown_Q },
            { KeyCode.E, KeyDown_E },
            { KeyCode.R, KeyDown_R },
            { KeyCode.Z, KeyDown_Z }
        };
    }
    private void KeyDown_W() {  }        
    private void KeyDown_S() {  }
    private void KeyDown_A() {  }
    private void KeyDown_D() {  }
    private void KeyDown_Space() {  }
    private void KeyDown_C() { }
    private void KeyDown_Q() { }
    private void KeyDown_E() { }
    private void KeyDown_R() { }
    private void KeyDown_Z() { }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKey(dic.Key))
                {
                    dic.Value();
                    state = dic.ToString();
                }
            }
        }
    }
}
