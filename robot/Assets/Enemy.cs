using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void TakeDamage(int damagePoints) {
		health -= damagePoints;


		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
