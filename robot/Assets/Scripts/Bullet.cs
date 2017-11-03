using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageValue;
	public string targetTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == targetTag) {
			Debug.Log ("Hit enemy");

			Entity enemy = collision.gameObject.GetComponent<Entity> ();

			enemy.TakeDamage (damageValue);
		}
	}
}
