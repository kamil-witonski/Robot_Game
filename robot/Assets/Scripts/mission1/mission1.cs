using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mission1 : mission {

	public AudioClip state_audio1;
	public AudioClip state_audio2;
	public AudioClip state_audio3;

	public AudioSource audio_source;

	public Transform osprey_pickup;
	public GameObject osprey;

	private Osprey osprey_script;
	private bool audio2played = false;

	// Use this for initialization
	void Start () {
		//play mission sound 1
		audio_source.clip = state_audio1;
		audio_source.Play ();
		//show coms officer

		osprey_script = osprey.GetComponent<Osprey> ();

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (mission_state == 1) {
			//show objectives
			objective1Text.text = "Eliminate Enemies " + eneimies_killed.ToString() + "/10";
		
			if (eneimies_killed >= 10) {
				mission_state = 2;

				if (!audio2played) {
					audio_source.clip = state_audio2;
					audio_source.Play ();
					audio2played = true;
				}
			}
		}

		if(mission_state == 2) {
			//proceed to landing zone
			objective1Text.text = "Proceed to the landing zone for extraction";

			osprey_script.targets [0] = osprey_pickup;
			osprey_script.targetIndex = 0;

			//mission_state = 3;

			//enable smoke

			//enable ospray

			//set the point of travel here

			//fade out when it gets close

			//load in the base and add uncloks
		}
	}
}
