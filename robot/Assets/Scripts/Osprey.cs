using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osprey : MonoBehaviour {

	public List<Transform> targets;
	public GameObject load;
	public int targetIndex = 0;
	public float speed = 10;

	public float distanceToNextTarget;

	private Rigidbody rigi;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		load.transform.parent = this.transform;
		load.transform.position = this.transform.position;
		load.transform.position = new Vector3(load.transform.position.x, load.transform.position.y - 5, load.transform.position.z);
		rigi = load.GetComponent<Rigidbody>();
		rigi.useGravity = false;

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveTowards(targets[targetIndex]);

		//when target reached drop the load
		if(distanceToNextTarget < 5) {
			// Debug.Log("WE HEREE");

			StartCoroutine(WaitFor());
			// Debug.Log("WAITING???");
		}

		if(targetIndex == 1 && distanceToNextTarget < 5) {
			// Debug.Log("Finished");
			audio.Stop();
		}
	}

	void MoveTowards(Transform target) {
		Vector3 targetDirection = target.position - transform.position;
		float movingspeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

		Vector3 rotatDir = Vector3.RotateTowards(transform.position, targetDirection, movingspeed, 0.0f);
		transform.rotation = Quaternion.LookRotation(rotatDir);

		distanceToNextTarget = Vector3.Distance(target.position, transform.position);
	}

	IEnumerator WaitFor()
	{
		var test = true;

		while (test) {
			// Debug.Log("Waiting");
			yield return new WaitForSeconds(3.0f);

			// Debug.Log("DROP LOAD");
			rigi.useGravity = true;
			load.transform.parent = null;
			yield return new WaitForSeconds(4.0f);

			targetIndex = 1;
			// Debug.Log("FLY AWAY");
			test = false;
		}
	}
}
