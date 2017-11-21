using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour {
	public List<GameObject> topLegParts = new List<GameObject>();
	public List<Transform> topLegLocators = new List<Transform>();

	public List<GameObject> bodyParts = new List<GameObject>();
	public List<Transform> bodyLocators = new List<Transform>();


	public int currentBodyIndex = 0;
	public int currentTopLegIndex = 0;

	// Use this for initialization
	void Start () {
		
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

		Debug.Log(currentTopLegIndex);
	}

	int changeIndex(int direction, int max, int currentIndex) {

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


			if(count == 1) {
				new_part.transform.localScale = new Vector3(new_part.transform.localScale.x, new_part.transform.localScale.y * -1, new_part.transform.localScale.z);
			}

			count++;

			// return new_part;

		}


		
	}
}
