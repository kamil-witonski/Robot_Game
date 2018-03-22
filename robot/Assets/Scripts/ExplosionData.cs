using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionData {

	private Vector3 explosionPos;
	private float force;
	private float radius;

	public ExplosionData(Vector3 position, float force, float radius) {
		this.explosionPos = position;
		this.force = force;
		this.radius = radius;
	}

	public Vector3 getPosition() {
		return this.explosionPos;
	}

	public float getForce() {
		return this.force;
	}

	public float getRadius() {
		return this.radius;
	}
}

