using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	public float maxHealth = 100f;
	public float health = 100f;

	void Start(){
		maxHealth = health;
	}

	public virtual void Die(){}

	public virtual void TakeDamage(int damagePoints) {
		health -= damagePoints;

		if (health <= 0f) {
			Die();
		}
	}
}
