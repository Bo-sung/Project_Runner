using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scr.PlayerScr
{
    public class send_col : MonoBehaviour
    {
        private void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag("Player"))
            {
                if (gameObject.transform.name == "Head")
                {
                    transform.parent.GetComponent<Enemy>().Attacked();
                }
            }
        }
    }
}
