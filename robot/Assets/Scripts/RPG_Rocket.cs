using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Rocket : MonoBehaviour {

	public AudioClip explosionSound;
	public int damageValue;
	public bool use_particle;
	public ParticleSystem particles;

	void Start() {
		
	}


	void Explosion()
	{
		var rig = GetComponent<Rigidbody>();
		rig.isKinematic = true;

		var rend = GetComponent<Renderer>();
		rend.enabled = false;

		Collider[] hitColliders = Physics.OverlapSphere (transform.position, 10f);
		int i = 0;

		while (i < hitColliders.Length) {

			Debug.Log (hitColliders [i].tag);

			if (hitColliders [i].tag == "enemy") {
				Debug.Log ("Explosion hit kill ududde");

				var enemy = hitColliders [i].gameObject.GetComponent<Enemy> ();
				enemy.TakeDamage (damageValue);

			}
			i++;
		}

		AudioSource.PlayClipAtPoint(explosionSound, transform.position);

		//particl system
		var explosion = GetComponent<ParticleSystem>();
		explosion.Play();

		if (use_particle) {
			var part = Instantiate (particles, transform.position, transform.rotation);
			part.Play ();
		}


		Destroy(gameObject, explosion.duration);
	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log("explosion");
		Explosion();


	}
}
