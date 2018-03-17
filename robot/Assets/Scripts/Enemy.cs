using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Entity {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public override void Die()
	{
		Debug.Log ("JEA:LTH" + health);
		//gameObject.SetActive (false);
		this.GetComponent<enemy_patrol>().enabled = false;

		//Destroy (gameObject);
	}
}
