using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	//aviable weapons
	public List<GameObject> weapons = new List<GameObject>(); 

	//user specific weapon set up
	public List<GameObject> userWeapons = new List<GameObject> ();

	public List<Gun> guns = new List<Gun>();
	public List<List<Gun>> gunsTest = new List<List<Gun>>();
	public int numberOfGuns = 3;
	public int currentGunIndex = 0;
	public int currentFireSide = 0;

	public List<Transform> locations = new List<Transform>();
	public Transform aimTarget;

	public bool isAllowedToFire;


	private float nextFire = 0;

	// Use this for initialization
	void Start () {
		//add machine gun

		// loop over the weapons list and load them up
		for(var i = 0; i < numberOfGuns; i++) {

			var pairs = new List<Gun>();

			foreach(Transform child in locations[i]) {
				GameObject obj = (GameObject) Instantiate(weapons[i], child.transform.position, child.transform.rotation);

				obj.transform.parent = child.transform;
				obj.transform.localScale = new Vector3(5f, 5f, 5f);

				var gun = obj.GetComponent<Gun> ();

				// guns.Add(obj.GetComponent<Gun>());
				pairs.Add(gun);

				//gun.lookAtTarget = aimTarget;




			}	

			gunsTest.Add(pairs);
		}


		Debug.Log(gunsTest[0][0]);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && isAllowedToFire) {

			// foreach(Gun gun in gunsTest[currentGunIndex]) {
			// 	gun.Fire();
			// }


			var fireRate = gunsTest[currentGunIndex][currentFireSide].fireRate / 2;

			if(Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				currentFireSide = (currentFireSide== 0) ? 1 : 0;	
			}

			gunsTest[currentGunIndex][currentFireSide].Fire();

			Debug.Log("Currenst Side FIre" + currentFireSide);
		}









// if (Time.time > nextFire) {
// 			//increase the timer for next fire
// 			nextFire = Time.time + fireRate;

// 			//instantiate a new bullet
// 			var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawnList[currentGunIndex].position, bulletSpawnList[currentGunIndex].rotation);
// 			//add force to bullet to send it flying
// 			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * bulletForce);
// 			//destroy the bullet after 5 seconds
// 			Destroy (bullet, 5.0f);

// 			//play audio clip at position
// 			AudioSource.PlayClipAtPoint(fire_sound, transform.position);

// 			//select the next gun to shoot from
// 			currentGunIndex++;

// 			//check if there is a gun at this pos?
// 			if (currentGunIndex >= bulletSpawnList.Count) {
// 				//reset the gun index
// 				currentGunIndex = 0;
// 			}
// 		}








		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			Debug.Log("Gun number: " + gunsTest.Count);
			currentGunIndex++;
			if (currentGunIndex >= gunsTest.Count) {
				//reset the gun index
				currentGunIndex = 0;
			}
		}

	}
}
