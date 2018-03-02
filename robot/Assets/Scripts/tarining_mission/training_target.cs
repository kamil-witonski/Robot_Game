using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training_target : MonoBehaviour {

	private training_mission mission_script;


	void Start() {
		GameObject mission = GameObject.Find ("mission_ctrl");
		mission_script = mission.GetComponent<training_mission>();

	}

	void OnCollisionEnter(Collision col) {
		if (col.transform.tag == "player_bullet") {
			Debug.Log ("asdfgas");

			if (mission_script.mission_status == 1) {
				mission_script.targets_shot += 1;
			}

		}
	}
}
