using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jet_pack_trigger : MonoBehaviour {

	private training_mission mission_script;

	void Start() {
		GameObject mission = GameObject.Find ("mission_ctrl");
		mission_script = mission.GetComponent<training_mission>();

	}

	void OnTriggerEnter (Collider col) {
		if (col.transform.tag == "Player") {
			mission_script.mission_status = 3;
		}
	}
	

}
