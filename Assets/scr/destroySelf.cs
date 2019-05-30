using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour {
    public float lifeTime;

    public bool activation = true;
    // Use this for initialization
	void Start ()
    {
	    if (activation)
	    {
		    Destroy(this.gameObject, lifeTime);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		if (activation)
		{
			Destroy(this.gameObject, lifeTime);
		}
		
	}
}
