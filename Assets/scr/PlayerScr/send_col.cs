using System;
using System.Collections;
using System.Collections.Generic;
using PlayerInitiallize;
using UnityEngine;

namespace scr.PlayerScr
{
    public class send_col : MonoBehaviour
    {
        private void OnTriggerEnter(Collider col)
        {
            if (col.transform.CompareTag("Player"))
            {
                if (gameObject.transform.name == "Head")
                {
                    //transform.parent.GetComponent<Enemy>().Attacked();
                    User user = col.GetComponent<User>();
                    user.Attack(this.transform.parent.gameObject);
                }
            }
        }
    }
}
