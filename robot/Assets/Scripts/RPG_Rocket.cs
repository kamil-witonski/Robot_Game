using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Rocket : MonoBehaviour {

	public AudioClip explosionSound;
	public int damageValue;
	public bool use_particle;
	public ParticleSystem particles;

	void Explosion(Collision bulletCollider)
	{
		var rig = GetComponent<Rigidbody>();
		rig.isKinematic = true;

		var rend = GetComponent<Renderer>();
		rend.enabled = false;

		//get all the coliders withn this area
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, 10f);
		int i = 0;

		//check all the colliders 
		while (i < hitColliders.Length) {
			//when the enemi is found
			if (hitColliders [i].tag == "enemy") {
				var enemy = hitColliders [i].gameObject.GetComponent<Enemy> ();

				//gather the explosion data and send top the take damage function
				ExplosionData data = new ExplosionData (bulletCollider.contacts[0].point, 2500f, 15f);
				enemy.TakeDamage (damageValue, data);

			}
			i++;
		}


		AudioSource.PlayClipAtPoint(explosionSound, transform.position);

		//particl system shows the explosion
		var explosion = GetComponent<ParticleSystem>();
		explosion.Play();

		if (use_particle) {
			var part = Instantiate (particles, transform.position, transform.rotation);
			part.Play ();
		}

		//destroy the bullet 
		Destroy(gameObject, explosion.duration);
	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log("explosion");
		Explosion(coll);


	}
}
