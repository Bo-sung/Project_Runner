using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBG : MonoBehaviour {
	public float ScrollSpeed = 0.5f;
	float Target_Offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Target_Offset += Time.deltaTime * ScrollSpeed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Target_Offset, 0 );
	}
}
