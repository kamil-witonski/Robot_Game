﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Die()
	{
		Debug.Log ("Oh no its dead!!!!");
	}
}
