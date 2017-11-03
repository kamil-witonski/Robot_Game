using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public int health = 100;

	public virtual void Die(){}

	public void TakeDamage(int damagePoints) {
		health -= damagePoints;


		if (health <= 0) {
			Die();
		}
	}
}
