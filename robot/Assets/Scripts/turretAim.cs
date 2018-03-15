using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAim : MonoBehaviour {

	private float shotTime = 0f;
	private float shotInterval = 5f;
	public Transform target;
	public bool enableShoot = false;

	public Transform bullet_spawn_point;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetPos = new Vector3 (90, target.transform.position.y, 0);

		transform.LookAt (targetPos);
		//transform.eulerAngles = new Vector3 (-90, 0, transform.eulerAngles.z);

		//LookAtPlayer ();

		//make sure we are within shooting range and check the time from last time shot
		if (enableShoot && (Time.time - shotTime) > shotInterval) {
			shootAtPlayer ();
		}
	}

	void LookAtPlayer()
	{
		var direction = target.transform.position - transform.position;
		direction.y += 90;
		//direction.x += 90;
		var rotation = Quaternion.LookRotation (direction);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 2f);
	}

	//shoot at the player
	void shootAtPlayer()
	{
		shotTime = Time.time;
		var bullet = (GameObject)Instantiate(projectile, bullet_spawn_point.position, Quaternion.LookRotation (target.transform.position - transform.position));
		var direction = target.transform.position - transform.position;

		//add force to bullet to send it flying
		bullet.GetComponent<Rigidbody> ().AddForce (direction * 155);
		//destroy the bullet after 5 seconds
		Destroy (bullet, 5.0f);
	}

}
