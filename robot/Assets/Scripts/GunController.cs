using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


	public List<GameObject> weapons = new List<GameObject>(); 

	public List<Gun> guns = new List<Gun>();
	public List<List<Gun>> gunsTest = new List<List<Gun>>();
	public int numberOfGuns = 3;
	public int currentGunIndex = 0;
	public int currentFireSide = 0;

	public List<Transform> locations = new List<Transform>();


	// Use this for initialization
	void Start () {
		//add machine gun

		for(var i = 0; i < weapons.Count; i++) {

			var pairs = new List<Gun>();

			foreach(Transform child in locations[i]) {
				GameObject obj = (GameObject) Instantiate(weapons[i], child.transform.position, child.transform.rotation);

				obj.transform.parent = child.transform;
				
				// guns.Add(obj.GetComponent<Gun>());
				pairs.Add(obj.GetComponent<Gun>());
			}	

			gunsTest.Add(pairs);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {

			// foreach(Gun gun in gunsTest[currentGunIndex]) {
			// 	gun.Fire();
			// }

			gunsTest[currentGunIndex][currentFireSide].Fire();

			currentFireSide = (currentFireSide== 0) ? 1 : 0;
			Debug.Log("Currenst Side FIre" + currentFireSide);
		}

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
