using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death_screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void mainMenu() {
		SceneManager.LoadScene("main_menu");
	}

	public void exit() {
		Application.Quit ();
	}
}
