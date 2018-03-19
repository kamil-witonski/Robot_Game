using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemeyCheck : MonoBehaviour {


	public mission mission_obj;
	private Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.health <= 0) {
			mission_obj.eneimies_killed++;

			Destroy (this);
		}


	}
}
