using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	//this is a base class for any typoe of gun
	public GameObject bulletPrefab;
	public float fireRate = 0.1f;
	public float bulletForce = 75f;
	public List<Transform> bulletSpawnList;
	public AudioClip fire_sound;

	public Transform lookAtTarget = null;


	private float nextFire = 0f;
	private int currentGunIndex = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void Fire()
	{
		//dont fire until certain time passed
		if (Time.time > nextFire) {
			//increase the timer for next fire
			nextFire = Time.time + fireRate;

			//instantiate a new bullet
			var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawnList[currentGunIndex].position, bulletSpawnList[currentGunIndex].rotation);
			//add force to bullet to send it flying
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * bulletForce);
			//destroy the bullet after 5 seconds
			Destroy (bullet, 5.0f);

			//play audio clip at position
			AudioSource.PlayClipAtPoint(fire_sound, transform.position);

			//select the next gun to shoot from
			currentGunIndex++;

			//check if there is a gun at this pos?
			if (currentGunIndex >= bulletSpawnList.Count) {
				//reset the gun index
				currentGunIndex = 0;
			}
		}
	}
}
