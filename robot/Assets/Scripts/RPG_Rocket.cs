using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Rocket : MonoBehaviour {

	public AudioClip explosionSound;

	void Explosion()
	{
		var rig = GetComponent<Rigidbody>();
		rig.isKinematic = true;

		var rend = GetComponent<Renderer>();
		rend.enabled = false;

		AudioSource.PlayClipAtPoint(explosionSound, transform.position);

		//particl system
		var explosion = GetComponent<ParticleSystem>();
		explosion.Play();
		Destroy(gameObject, explosion.duration);
	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log("explosion");
		Explosion();


	}
}
