using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training_mission : MonoBehaviour {

	public int mission_status = 0;

	public int targets_shot = 0;

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

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {

		//shooting range
		if (mission_status == 1) {
			Debug.Log ("targets shot: " + targets_shot);

			if (!targetPlayed) {
				ctr = mounting.transform.GetChild(0).GetComponent<GunController> ();
				Debug.Log ("playing 2");
				targetPlayed = true;
				AudioSource.PlayClipAtPoint (train2, player.transform.position);
			}

			if (targets_shot >= 5) {
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

		}

		if (mission_status == 3) {
			//spawn enemy

			Debug.Log ("playing 4");

			if (!shieldPlayed) {
				shieldPlayed = true;
				AudioSource.PlayClipAtPoint (train4, player.transform.position);
			}




			if (Input.GetKeyDown (KeyCode.G)) {
				//shield activated 

				//play sound
				AudioSource.PlayClipAtPoint(train5, player.transform.position);

			}


		}


	}
}
