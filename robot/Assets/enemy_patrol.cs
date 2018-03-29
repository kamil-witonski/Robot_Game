using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_patrol : MonoBehaviour {

	public Transform[] patrolPoints;
	public bool stopAtEnd;
	private int currentPatrolPoint;
	public float moveSpeed;

	private Animator anim;

	private bool rotating;
	public float rotationSpeed = 2.0f;

	public bool isAttack = false;
	public bool preventEvade = false;

	private GameObject player;
	private Transform evadingPosition;
	public Transform bullet_spawn_point;

	public float maxLookDistance = 50f;
	public float maxAttackDistance = 40f;
	public float shotInterval = 0.5f;

	private float distanceFromPlayer;

	public GameObject projectile;
	private Vector3 evadepos;

	private float shotTime = 0f;
	private float evadeTime = 0f;
	private float evadeInterval = 4f;

	private int lookForPlayerLimiter = 0;

	private CharacterController charCtrl;

	private AudioSource audio_source;
	public AudioClip shoot_clip;

	// Use this for initialization
	void Start () {
		//check if there are patrols to use
		if(patrolPoints.Length != 0) {
			transform.position = patrolPoints [0].position;
		}

		currentPatrolPoint = 0;
		anim = GetComponent<Animator> ();

		player = GameObject.FindWithTag ("Player");
		evadingPosition = transform;

		charCtrl = GetComponent<CharacterController> ();

		audio_source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//add counting to improve performance
		if (lookForPlayerLimiter > 30) {
				
			lookForPlayer ();

			lookForPlayerLimiter = 0;
		}

		//check if we in attack mode
		if (isAttack) {
			if (!preventEvade) {
				
				evadePositioning ();
			}
			attackPlayer ();
		} else {
			patrol ();
		}

		lookForPlayerLimiter++;
	}

	void lookForPlayer()
	{
		//check distance from player
		distanceFromPlayer = Vector3.Distance (player.transform.position, transform.position);

		if (isAttack) {
			return;
		}

		//check if we within the attack range
		if (distanceFromPlayer <= maxLookDistance) {
			isAttack = true;
			anim.SetLayerWeight (1, 1);

			float randNumber = Random.Range (0f, 10f);
			//get the evading position since we are in attack mode
			evadepos = new Vector3 (transform.position.x + randNumber, transform.position.y, transform.position.z + randNumber);
		}
	}

	//rotate the enemy toward the player
	void LookAtPlayer()
	{
		var direction = player.transform.position - transform.position;
		direction.y = 0;
		var rotation = Quaternion.LookRotation (direction);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);
	}

	//shoot at the player
	void shootAtPlayer()
	{
		shotTime = Time.time;
		var bullet = (GameObject)Instantiate(projectile, bullet_spawn_point.position, Quaternion.LookRotation (player.transform.position - transform.position));
		var direction = player.transform.position - transform.position;

		//add force to bullet to send it flying
		bullet.GetComponent<Rigidbody> ().AddForce (direction * 155);
		audio_source.clip = shoot_clip;
		audio_source.Play ();
		//destroy the bullet after 5 seconds
		Destroy (bullet, 5.0f);
	}

	//when player is within a specifid range enemy will start to look at the player and start shooting if is within shoot distance
	void attackPlayer()
	{
		LookAtPlayer ();

		//make sure we are within shooting range and check the time from last time shot
		if (distanceFromPlayer <= maxAttackDistance && (Time.time - shotTime) > shotInterval) {
			shootAtPlayer ();
		}
	}

	//start doing evade manouvers
	void evadePositioning()
	{
		//get a random number to move to
		float randNumber = Random.Range (-10f, 10f);

		//check the distance form evading position, if less than x set a new position
		if (Vector3.Distance (transform.position, evadepos) < 0.5f) {
			//create a new evade position to move to 
			evadepos = new Vector3 (transform.position.x + randNumber, transform.position.y, transform.position.z + randNumber);
			evadeTime = Time.time;
		} else {

			//check if the cooldown time between evading positions is reached and then move towards the next position
			if ((Time.time - evadeTime) > evadeInterval) {
				var direction = evadepos - transform.position;

				var movement = direction.normalized * moveSpeed * Time.deltaTime;

				if (movement.magnitude > direction.magnitude) {
					movement = direction;
				}

				charCtrl.Move (movement);

				//transform.position = Vector3.MoveTowards (transform.position, evadepos, moveSpeed * Time.deltaTime);
			}
		}
	}

	void patrol()
	{

		if (patrolPoints.Length == 0) {
			anim.SetBool ("is_walking", false);
			return;
		}

		float distanceToPoint = Vector3.Distance (transform.position, patrolPoints [currentPatrolPoint].position);

		//check the distance to the next patrol point
		if (distanceToPoint < 0.5f) {
			currentPatrolPoint++;
		}

		//check if there is anymore patrol points after this
		if (currentPatrolPoint >= patrolPoints.Length) {
			//check if the enmy should stop at end of the patrol route
			if (stopAtEnd != true) {
				currentPatrolPoint = 0;
				anim.SetBool ("is_walking", false);
			} else {
				currentPatrolPoint = patrolPoints.Length - 1;
			}

		}

		//move towards the actual point
		var direction = patrolPoints [currentPatrolPoint].position - transform.position;
		var movement = direction.normalized * moveSpeed * Time.deltaTime;

		if (movement.magnitude > direction.magnitude) {
			movement = direction;
		}

		charCtrl.Move (movement);

		anim.SetBool ("is_walking", true);

		if (patrolPoints.Length == 1) {
			anim.SetBool ("is_walking", false);
		}


		if (distanceToPoint > 3f && !preventEvade) {
			StartCoroutine (TurnTowards (patrolPoints[currentPatrolPoint].position));
		}

	}

	IEnumerator TurnTowards(Vector3 lookAtTarget) {
		Quaternion newRotation = Quaternion.LookRotation (lookAtTarget - transform.position);
		newRotation.x = 0;
		newRotation.z = 0;

		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
		yield return null;
	}
}
