using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Entity {

	public Slider healthBar;
    public ForceField forceField;

	public AudioSource audio_source;
	public AudioClip damageAlert;
	public AudioClip criticalHealth;

	private bool alertPlayed = false;

	// Use this for initialization
	void Start () {
		healthBar.value = CalculateHealth();
        //forceField = transform.root.GetComponent<ForceField>();
    }
	
	// Update is called once per frame
	void Update () {
		//play damage alert at half health
		if (health <= (maxHealth/ 2) && !alertPlayed) {
			audio_source.clip = damageAlert;
			audio_source.Play ();
			alertPlayed = !alertPlayed;
		}

		//play at 20% helth
		if (health <= (maxHealth / 5)) {



			if (audio_source.clip.name == "damage_alert" || !audio_source.isPlaying) {
				audio_source.clip = criticalHealth;
				audio_source.Play ();
			}
		}
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

		SceneManager.LoadScene ("dead_screen");
	}
}
