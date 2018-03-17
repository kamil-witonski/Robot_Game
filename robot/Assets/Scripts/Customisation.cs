using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customisation : MonoBehaviour {
	public List<GameObject> topLegParts = new List<GameObject>();
	public List<Transform> topLegLocators = new List<Transform>();

	public List<GameObject> bottomLegParts = new List<GameObject>();
	public List<Transform> bottomLegLocators = new List<Transform>();

	public List<GameObject> bodyParts = new List<GameObject>();
	public List<Transform> bodyLocators = new List<Transform>();

	public List<GameObject> gunMounts = new List<GameObject>();
	public Transform mountsLocation;

	public List<int> mountGunIndexes = new List<int> ();

	public int currentBodyIndex = 0;
	public int currentTopLegIndex = 0;
	public int currentBottomLegIndex = 0;
	public int currentMountIndex = 0;

	public GameObject armourSelector;
	public GameObject legSelector;
	public GameObject bottomLegSelector;

	// Use this for initialization
	void Start () {
		
		//load specific values based on the level we are in
		checkLevels();

		//build the robot
		changePart(topLegLocators, topLegParts[PlayerPrefs.GetInt("armour_top_leg")]);
		changePart(bodyLocators, bodyParts[PlayerPrefs.GetInt("armour_body")]);
		changePart(bottomLegLocators, bottomLegParts[PlayerPrefs.GetInt("armour_bottom_leg")]);
		changeMounting ();
	}

	void checkLevels()
	{
		if (SceneManager.GetActiveScene ().name == "test_base") {
			CheckUnlocks ();
		}

		if (SceneManager.GetActiveScene ().name == "training_area") {
			PlayerPrefs.SetInt ("mount_number", 0);
		}
	}

	void CheckUnlocks() {
		if (PlayerPrefs.GetInt ("unlock_level") > 0) {
			armourSelector.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("unlock_level") > 1) {
			legSelector.SetActive (true);
			bottomLegSelector.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			currentTopLegIndex = changeIndex(1, topLegParts.Count, currentTopLegIndex);
			changePart(topLegLocators, topLegParts[currentTopLegIndex]);
		}

		if (Input.GetKeyDown (KeyCode.Y)) {
			currentTopLegIndex = changeIndex(-1, topLegParts.Count, currentTopLegIndex);
			changePart(topLegLocators, topLegParts[currentTopLegIndex]);
		}

		if (Input.GetKeyDown (KeyCode.U)) {
			currentBodyIndex = changeIndex(1, bodyParts.Count, currentBodyIndex);
			changePart(bodyLocators, bodyParts[currentBodyIndex]);
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			currentBodyIndex = changeIndex(-1, bodyParts.Count, currentBodyIndex);
			changePart(topLegLocators, topLegParts[currentTopLegIndex]);
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			currentBottomLegIndex = changeIndex(1, bottomLegParts.Count, currentBottomLegIndex);
			changePart(bottomLegLocators, bottomLegParts[currentBottomLegIndex]);
		}

		//Debug.Log(currentTopLegIndex);
	}

	public void BodyArmourBtnClick(int dir) {
		currentBodyIndex = changeIndex(dir, bodyParts.Count, currentBodyIndex);
		changePart(bodyLocators, bodyParts[currentBodyIndex]);

		//save the choice
		PlayerPrefs.SetInt("armour_body", currentBodyIndex);
	}

	public void TopLegArmourBtnClick(int dir) {
		currentTopLegIndex = changeIndex(dir, topLegParts.Count, currentTopLegIndex);
		changePart(topLegLocators, topLegParts[currentTopLegIndex]);

		PlayerPrefs.SetInt ("armour_top_leg", currentTopLegIndex);
	}

	public void BottomLegArmourBtnClick(int dir) {
		currentBottomLegIndex = changeIndex(dir, bottomLegParts.Count, currentBottomLegIndex);
		changePart(bottomLegLocators, bottomLegParts[currentBottomLegIndex]);
		PlayerPrefs.SetInt ("armour_bottom_leg", currentBottomLegIndex);
	}

	public void mountClick(int dir) {
		currentMountIndex = changeIndex (dir, gunMounts.Count, currentMountIndex);
		PlayerPrefs.SetInt ("mount_number", currentMountIndex);
		changeMounting ();
	}

	void changeGun(int dir, int gunIndex) {
		GameObject mounting = GameObject.Find("mounting");
		GunController weapons = mounting.GetComponentInChildren<GunController> ();

		int currentGunIndex = changeIndex (dir, weapons.weapons.Count, PlayerPrefs.GetInt ("gun" + gunIndex));

		PlayerPrefs.SetInt ("gun" + gunIndex, currentGunIndex);

		changeMounting ();
	}

	public void changeGun0(int dir)
	{
		changeGun (dir, 0);
	}

	public void changeGun1(int dir)
	{
		changeGun (dir, 1);
	}

	public void changeGun2(int dir)
	{
		changeGun (dir, 2);
	}

	//function used to cycle through lists using the int for current index
	//max counter and the direction +1 or -1 to determnine what the next number in the index is going to be
	int changeIndex(int direction, int max, int currentIndex) {

		Debug.Log ("index: " + currentIndex);

		if (direction == 1) {
			currentIndex++;
		} else if (direction == -1) {
			currentIndex--;
		}

		//dont go past the list count
		if (currentIndex > max - 1) {
			currentIndex = 0;
		}

		if (currentIndex < 0) {
			currentIndex = max - 1;
		}

		return currentIndex;
	}

	//finds the old part by the location transform and places a new part
	void changePart(List<Transform> locators, Object newPart){
		//find the chassis
		// GameObject chassis = transform.Find ("Armature").gameObject;
		//within the chassis find the required gameobject
		// Transform partLocation = chassis.transform.Find(partLocationString);

		//remove any objects within it
		// List<GameObject> to_delete = new List<GameObject> ();

		// foreach (Transform child in partLocation) {
		// 	to_delete.Add (child.gameObject);
		// }

		foreach(Transform child in locators) {
			// to_delete.Add(child.gameObject);
			// Destroy(child.gameObject);

			foreach(Transform insideChild in child) {
				Destroy(insideChild.gameObject);
			}


		}
			
		// to_delete.ForEach (child => Destroy (child));

		var count = 0;
		foreach(Transform location in locators) {

			//add the new bumper based on an index
			GameObject new_part = Instantiate (newPart) as GameObject;
			new_part.transform.position = location.position;

			new_part.transform.parent = location;
			new_part.transform.localRotation = Quaternion.Euler (-90, 0, 0);

			//if this is the second pass in the function flip the part along its origin
			if(count == 1) {
				new_part.transform.localScale = new Vector3(new_part.transform.localScale.x, new_part.transform.localScale.y * -1, new_part.transform.localScale.z);
			}

			count++;

			// return new_part;

		}
	}

	//changes the mountig system and fills up with guns
	void changeMounting(){
		foreach(Transform insideChild in mountsLocation) {
			Destroy(insideChild.gameObject);
		}
			
		GameObject new_part = Instantiate (gunMounts[PlayerPrefs.GetInt("mount_number")]) as GameObject;
		new_part.transform.position = mountsLocation.position;

		new_part.transform.parent = mountsLocation;
		new_part.transform.localRotation = mountsLocation.localRotation;

		GunController ctr = new_part.GetComponent<GunController> ();
		//ctr.isAllowedToFire = true;
		ctr.initialise ();
	}


}
