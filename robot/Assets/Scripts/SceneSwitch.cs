using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void switchScene(string secenName) {

		int mission = PlayerPrefs.GetInt ("next_mission");

		Debug.Log ("misison::" + mission);

		if(mission == 0) {
			SceneManager.LoadScene("training_area");
		} else if (mission == 1) {
			SceneManager.LoadScene("city");
		} else if (mission == 2) {
			SceneManager.LoadScene("mission2");
		}



	}
}
