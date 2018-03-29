using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_continue_button : MonoBehaviour {

	public GameObject contBtn;
	public SceneSwitch sceneSwitch;

	public GameObject controls_info;
	private bool show_ctr = false;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("next_mission", 999) != 999) {
			//Debug.Log ("heheheheheheheheheehheehhehehehe");
			contBtn.SetActive (true);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onContinueClick() {
		sceneSwitch.switchScene ("");
	}

	public void showControls() {

		show_ctr = !show_ctr;

		if (show_ctr) {
			controls_info.SetActive (true);

		} else {
			controls_info.SetActive (false);

		}

	}
}
