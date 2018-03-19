using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mission1end : mission_end {

	public override void loadNextLevel() {
		PlayerPrefs.SetInt ("unlock_level", 1);
		PlayerPrefs.SetInt ("next_mission", 2);

		//switch level
		SceneManager.LoadScene ("test_base", LoadSceneMode.Single);
	}
}
