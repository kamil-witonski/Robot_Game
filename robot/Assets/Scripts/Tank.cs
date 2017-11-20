using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

	public Transform moveTarget;
	public GameObject aimTarget;
	public GameObject tankCanon;

	public float speed;

	public bool moveEnabled = true;

	private float distanceToNextTarget;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(moveEnabled) {
			MoveTowards(moveTarget);
		}

		AimAt();

		shoot();
	}

	void MoveTowards(Transform target) {
		Vector3 targetDirection = target.position - transform.position;
		float movingspeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

		// Vector3 rotatDir = Vector3.RotateTowards(transform.position, targetDirection, movingspeed, 0.0f);
		// transform.rotation = Quaternion.LookRotation(rotatDir);

		distanceToNextTarget = Vector3.Distance(target.position, transform.position);
	}

	void AimAt()
	{

		// var lookAt = new Vector3(0, 180, aimTarget.transform.position.z);

		// tankCanon.transform.LookAt(lookAt);
		Vector3 targetDirection = aimTarget.transform.position - tankCanon.transform.position;
		float movingspeed = speed * Time.deltaTime;

		Vector3 rotatDir = Vector3.RotateTowards(tankCanon.transform.position, targetDirection, movingspeed, 0.0f);
		tankCanon.transform.rotation = Quaternion.LookRotation(rotatDir);		
		// tankCanon.transform.rotation = rotatDir;
	}

	void shoot(){

	}
}
