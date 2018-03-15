using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osprey_rotor : MonoBehaviour {

	public Transform rotor_l; 
	public Transform rotor_r;

	public bool engines_on = false;

	//private Vector3 rotation = new Vector3(0f, 20f, 0f);

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (engines_on) {
			
			rotor_l.transform.Rotate (Vector3.forward * Time.deltaTime * 1500);
			rotor_r.transform.Rotate (Vector3.forward * Time.deltaTime * 1500);
		}
	}
}
