using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "enemy") {
			Debug.Log ("Hit enemy");

			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();

			enemy.TakeDamage (damageValue);
		}
	}
}
