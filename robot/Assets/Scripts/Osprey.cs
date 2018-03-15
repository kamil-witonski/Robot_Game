using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osprey : MonoBehaviour {

	public List<Transform> targets;
	public GameObject load;
	public int targetIndex = 0;
	public float speed = 10;

	public Transform load_locationl;

	public float distanceToNextTarget;

	private Rigidbody rigi;
	private AudioSource audio;

	private Vector3 lookAdjust = new Vector3 (0f, 90f, 0f);

	// Use this for initialization
	void Start () {
		load.transform.parent = this.transform;
		load.transform.position = this.transform.position;
		load.transform.position = new Vector3(load_locationl.position.x, load_locationl.position.y, load_locationl.position.z);
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

	void LateUpdate()
	{

	}

	void MoveTowards(Transform target) {
		Vector3 targetDirection = target.position - transform.position;
		float movingspeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

		//Vector3 rotatDir = Vector3.RotateTowards(transform.position, targetDirection, movingspeed, 0.0f);
		//transform.rotation = Quaternion.LookRotation(rotatDir);

		//Vector3 rotatata = new Vector3 (0f, -180f, 0f);

		//transform.LookAt (target.position);

		var lookdir = Quaternion.LookRotation (target.position);
		lookdir *= Quaternion.Euler (lookAdjust);

		transform.rotation = Quaternion.Slerp (transform.rotation, lookdir, Time.deltaTime * 0.5f);

//		transform.rotation 

		//transform.localRotation = Quaternion.Euler (rotatata);

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
			lookAdjust = new Vector3 (0f, 270f, 0f);
			// Debug.Log("FLY AWAY");
			test = false;
		}
	}
}
