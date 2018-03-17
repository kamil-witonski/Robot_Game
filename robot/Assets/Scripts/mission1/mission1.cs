using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mission1 : MonoBehaviour {

	public int eneimies_killed = 0;
	public int mission_state = 0;

	public GameObject comms_offier;
	public Text objective1Text;

	public AudioClip state_audio1;

	public AudioSource audio_source;

	// Use this for initialization
	void Start () {
		//play mission sound 1
		audio_source.clip = state_audio1;
		audio_source.Play ();
		//show coms officer


	}
	
	// Update is called once per frame
	void Update () {
	
		if (mission_state == 1) {
			//show objectives
			objective1Text.text = "Eliminate Enemies " + eneimies_killed.ToString() + "/10";
		
			if (eneimies_killed >= 10) {
				mission_state = 2;
			}
		}

		if(mission_state == 2) {
			//proceed to landing zone
			objective1Text.text = "Proceed to the landing zone for extraction";


			//enable smoke

			//enable ospray

			//set the point of travel here

			//fade out when it gets close

			//load in the base and add uncloks
		}
	}
}
