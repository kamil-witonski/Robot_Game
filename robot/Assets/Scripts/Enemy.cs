using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Entity {

	//private Rigidbody[] ragdoll_items =  new Rigidbody[13];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	private void enemyDeath() {
		this.GetComponent<enemy_patrol>().enabled = false;
		this.GetComponent<Animator> ().enabled = false;

		this.GetComponent<BoxCollider> ().enabled = false;
	}

	public override void Die()
	{
		enemyDeath ();

		foreach(Rigidbody rig in this.GetComponentsInChildren<Rigidbody>()) {
			rig.isKinematic = false;
			rig.useGravity = true;
		}

	}

	public override void Die(ExplosionData explosion)
	{
		enemyDeath ();

		foreach(Rigidbody rig in this.GetComponentsInChildren<Rigidbody>()) {
			rig.isKinematic = false;
			rig.useGravity = true;

			Debug.Log ("adding explosion");
			rig.AddExplosionForce(explosion.getForce(), explosion.getPosition(), explosion.getRadius());
		}

	}
}
