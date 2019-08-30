using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using PlayerInitiallize;

public class InputManager : MonoBehaviour
{
    Dictionary<KeyCode, Action> keyDictionary;//델리게이트 사용
    private string state;
    public Player PlayerChar;
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
    private void KeyDown_W() { Debug.Log("W"); }
    private void KeyDown_S() { Debug.Log("S"); }
    private void KeyDown_A() { Debug.Log("A"); }
    private void KeyDown_D() { Debug.Log("D"); }
    private void KeyDown_Space() { Debug.Log("Space"); PlayerChar.Jump();  }
    private void KeyDown_C() { Debug.Log("C"); }
    private void KeyDown_Q() { Debug.Log("Q"); }
    private void KeyDown_E() { Debug.Log("E"); }
    private void KeyDown_R() { Debug.Log("R"); }
    private void KeyDown_Z() { Debug.Log("Z"); }
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
