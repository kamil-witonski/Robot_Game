using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMissionState : MonoBehaviour {

	public mission mission_obj;

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player" && mission_obj.mission_state != 1) {
			Debug.Log("we here");
			mission_obj.mission_state = 1;
			this.enabled = false;
		}
	}
}
