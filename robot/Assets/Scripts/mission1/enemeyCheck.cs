using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemeyCheck : MonoBehaviour {


	public mission1 mission;
	private Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (enemy.health);

		if (enemy.health <= 0) {
			mission.eneimies_killed++;

			Destroy (this);
		}


	}
}
