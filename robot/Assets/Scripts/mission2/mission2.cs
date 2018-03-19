using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mission2 : mission {

	public AudioClip state_audio1;
	public AudioClip state_audio2;
	public AudioClip state_audio3;

	public AudioSource audio_source;

	public Transform osprey_pickup;
	public GameObject osprey;

	private Osprey osprey_script;

	private bool audio1BeenPLayed = false;

	// Use this for initialization
	void Start () {
		//play mission sound 1
		audio_source.clip = state_audio1;
		audio_source.Play ();
		//show coms officer

		osprey_script = osprey.GetComponent<Osprey> ();

	}

	// Update is called once per frame
	void Update () {

		if (mission_state == 1) {
			//show objectives
			objective1Text.text = "Protect Asset " + eneimies_killed.ToString() + "/10";


			if (!audio1BeenPLayed) {
				audio_source.clip = state_audio2;
				audio_source.Play ();

				audio1BeenPLayed = true;
			}

			if (eneimies_killed >= 10) {
				audio_source.clip = state_audio3;
				audio_source.Play ();
				mission_state = 2;
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
