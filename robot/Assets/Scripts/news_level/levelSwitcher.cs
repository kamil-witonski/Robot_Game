using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSwitcher : MonoBehaviour {

	public int enemies_killed;
	public int mission_state;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//mission state 1 landed ready to party

		//mission state 2 - given info doing main obj

		//mission state 3 - done mian exit time

		//mission state 4 - enemies appear kill them???

		if (mission_state == 1) {
			//display the current eneimes killed status

			//displayt mission details

			//play audio
		}



		if (mission_state == 2 && enemies_killed >= 10) {
			//display new misson info

			//play aduio

			//show evac zone
		}



	}
}
