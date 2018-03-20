using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMissionNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("next_mission", 0);

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
