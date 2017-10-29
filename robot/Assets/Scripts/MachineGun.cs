using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {

	// public float fireRate;
	// public float bulletForce;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			Fire ();
		}
	}
}
