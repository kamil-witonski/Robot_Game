using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public int currentGun = 0;


	public float fireRate = 0.1f;
	public float rpgFireRate = 55f;
	private float nextFire = 0f;


	public List<Transform> bulletSpawnList;
	private int currentGunIndex = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//when button is pressed
		if (Input.GetKey (KeyCode.Mouse0)) {

			if(currentGun == 1) {
				Debug.Log("Shooting rocket");
				FireRocketGuns();
			} else {
				FireMachineGuns ();
				Debug.Log("Shooting Machine");
			}
		}
	}

//	void Fire() {
//		//loop over all the fire points and create a bullet from them
//		for (var i = 0; i < bulletSpawnList.Count; i++) {
//			Transform bulletSpawn = bulletSpawnList [i];
//
//			if (Time.time > nextFire) {
//				nextFire = Time.time + fireRate;
//
//				Debug.Log ("bullet POS: " + bulletSpawn.position);
//
//				var rotation = Quaternion.Euler (new Vector3 (bulletSpawn.rotation.x, bulletSpawn.rotation.y, bulletSpawn.rotation.z));
//
//				var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
//
//				bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 50);
//
//				Destroy (bullet, 5.0f);
//
//			}
//		}
//	}

	void FireMachineGuns()
	{
		//dont fire until certain time passed
		if (Time.time > nextFire) {
			//increase the timer for next fire
			nextFire = Time.time + fireRate;

			//instantiate a new bullet
			var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawnList[currentGunIndex].position, bulletSpawnList[currentGunIndex].rotation);
			//add force to bullet to send it flying
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 75);
			//destroy the bullet after 5 seconds
			Destroy (bullet, 5.0f);

			//select the next gun to shoot from
			currentGunIndex++;

			//check if there is a gun at this pos?
			if (currentGunIndex >= bulletSpawnList.Count) {
				//reset the gun index
				currentGunIndex = 0;
			}
		}
	}

	void FireRocketGuns()
	{
		//dont fire until certain time passed
		if (Time.time > nextFire) {
			//increase the timer for next fire
			nextFire = Time.time + rpgFireRate;

			//instantiate a new bullet
			var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawnList[currentGunIndex].position, bulletSpawnList[currentGunIndex].rotation);
			//add force to bullet to send it flying
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 75);
			//destroy the bullet after 5 seconds
			Destroy (bullet, 5.0f);

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
