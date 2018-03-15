using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopter : MonoBehaviour {

	public Transform rotor;
	public Transform back_rotor;

	private Vector3 rotation = new Vector3(0f, 20f, 0f);
	private Vector3 backRotation = new Vector3(20f, 0f, 0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rotor.transform.Rotate (Vector3.up * Time.deltaTime * 1500);
		back_rotor.transform.Rotate (Vector3.left * Time.deltaTime * 1000);
	}
}
