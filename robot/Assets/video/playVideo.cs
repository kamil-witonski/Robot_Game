using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playVideo : MonoBehaviour {

	public MovieTexture movie;

	RawImage rawImageComp;
	AudioSource audioS;

	// Use this for initialization
	void Start () {
		rawImageComp = GetComponent<RawImage> ();
		audioS = GetComponent<AudioSource> ();

		PlayerPrefs.SetInt ("unlock_level", 0);
		PlayerPrefs.SetInt ("armour_top_leg", 0); 

		PlayerPrefs.SetInt ("armour_body", 0);
		PlayerPrefs.SetInt ("armour_bottom_leg", 0);

		PlayClip ();
	}

	void Update() {
		if (!movie.isPlaying) {
			SceneManager.LoadScene ("test_base", LoadSceneMode.Single);
		}
	}

	void PlayClip() {
		rawImageComp.texture = movie;
		movie.Play ();
		audioS.clip = movie.audioClip;
		audioS.Play ();
	}

}
