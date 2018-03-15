using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class training_mission : MonoBehaviour {

	public int mission_status = 0;

	public int targets_shot = 0;

	public Transform smoke_loc1;
	public Transform smoke_loc2;
	public GameObject smoke;

	public AudioClip train1;
	public AudioClip train2;
	public AudioClip train3;
	public AudioClip train4;
	public AudioClip train5;

	public GameObject mounting;

	private GameObject player;
	private GunController ctr;
	private bool jetpackPlayed = false;
	private bool targetPlayed = false;
	private bool shieldPlayed = false;

	public Text mission_text; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");

		//play intro sound
		AudioSource.PlayClipAtPoint (train1, player.transform.position);
		mission_text.text = "Proceed to the shooting range";
		smoke.transform.position = smoke_loc1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//shooting range
		if (mission_status == 1) {
			Debug.Log ("targets shot: " + targets_shot);

			//display the amount of targets shot

			if (!targetPlayed) {
				ctr = mounting.transform.GetChild(0).GetComponent<GunController> ();
				Debug.Log ("playing 2");
				targetPlayed = true;
				AudioSource.PlayClipAtPoint (train2, player.transform.position);
				mission_text.text = "Shoot the targets";

			}

			if (targets_shot >= 10) {
				//targets hit do the jetpack
				Debug.Log("we here?>?????");

				ctr.isAllowedToFire = false;

				Debug.Log (ctr.isAllowedToFire);

				//play sound
			//	AudioSource.PlayClipAtPoint(train2, player.transform);
				Debug.Log ("playing 3");


				//set mission status
				mission_status = 2;
			}
		}

		//jet pack
		if (mission_status == 2 && !jetpackPlayed) {
			AudioSource.PlayClipAtPoint (train3, player.transform.position);
			jetpackPlayed = true;
			mission_text.text = "Press 'V' to operate the Jetpack";
			smoke.transform.position = smoke_loc2.transform.position;
		}

		if (mission_status == 3) {
			//spawn enemy

			Debug.Log ("playing 4");

			if (!shieldPlayed) {
				shieldPlayed = true;
				AudioSource.PlayClipAtPoint (train4, player.transform.position);
				mission_text.text = "Press 'G' to operate the shield";
			}




			if (Input.GetKeyDown (KeyCode.G)) {
				//shield activated 

				//play sound
				AudioSource.PlayClipAtPoint(train5, player.transform.position);

			}


		}


	}
}
