using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mission2end : mission_end {

	public override void loadNextLevel() {
		PlayerPrefs.SetInt ("unlock_level", 2);
		PlayerPrefs.SetInt ("next_mission", 3);
		//switch level
		SceneManager.LoadScene ("test_base", LoadSceneMode.Single);
	}
}
