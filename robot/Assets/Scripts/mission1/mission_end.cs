using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mission_end : MonoBehaviour {

	public mission mission_obj;
	public Image screen_blocker;
	public int mission_end_status;

	private float alpha;
	//private Renderer screen_blocker_rendrer;


	void Start() {
		//screen_blocker_rendrer = screen_blocker.GetComponent<Renderer> ();

		var col = screen_blocker.material.color;

		//var col = screen_blocker_rendrer.material.color;
		//var col = screen_blocker.color;
		col.a = 0;

		screen_blocker.material.color = col;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.transform.tag == "Player") {
			//end mission here


			if (mission_obj.mission_state == mission_end_status) {
				

				Debug.Log ("HELLOOOOOO!!!!!");

				//fade out
				FadeOut();

				loadNextLevel ();
			}
		}
	}

	public virtual void loadNextLevel() {
		
	}

	void FadeOut() {
		alpha += 0.2f;// * 0.2f * Time.deltaTime;

		//alpha = Mathf.Clamp (alpha, 0, 1);

		var col = screen_blocker.material.color;

		//var col = screen_blocker_rendrer.material.color;
		//var col = screen_blocker.color;
		col.a = alpha;

		screen_blocker.material.color = col;
	}
}
