using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathZone_scr : MonoBehaviour
{
    public GameObject GameoverUI;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            GameoverUI.SetActive(true);
            
        }
    }
}
