using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity {

	public Slider healthBar;
    public ForceField forceField;

	// Use this for initialization
	void Start () {
		healthBar.value = CalculateHealth();
        //forceField = transform.root.GetComponent<ForceField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	float CalculateHealth()
	{
		//Debug.Log("healths:::" + (health / maxHealth));
		return health/maxHealth;
	}

	public override void TakeDamage(int damagePoints) {
        //prevent damage if force field is active
        if(forceField.activated)
        {
            return;
        }

		health -= damagePoints;

		healthBar.value = CalculateHealth();

		if (health <= 0f) {
			Die();
		}
	}

	public override void Die()
	{
		Debug.Log ("Oh no its dead!!!!");
	}
}
