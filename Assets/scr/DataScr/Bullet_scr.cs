using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_scr : MonoBehaviour
{
    public List<GameObject> magazine;

    public float Power;
    public bool shoot;

    private void Update()
    {
        if (shoot)
        {
            magazine[0].transform.Translate(Vector3.right * Power * Time.deltaTime);
            if (magazine[0].transform.position.x >= 17)
            {
                shoot = false;
            }
        }
        else
        {
            magazine[0].transform.position = this.transform.position;
        }

    }
}
