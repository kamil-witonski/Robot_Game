using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : Gun {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			Fire ();
		}	
	}
}
