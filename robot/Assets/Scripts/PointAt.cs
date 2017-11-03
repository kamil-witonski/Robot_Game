﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (target.position);

		Vector3 relPos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relPos);

		transform.rotation = rotation;
	}
}
