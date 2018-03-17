using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMissionState : MonoBehaviour {

	public mission1 mission1;

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player") {
			mission1.mission_state = 1;
		}
	}
}
