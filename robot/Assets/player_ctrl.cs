using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ctrl : MonoBehaviour {

	//movement related variables
	public int movementSpeed = 2;
	public float robotRotationSpeed;
	public float aimSpeed = 1f;
	public int jumpSpeed;

	//object used for displaying the rotation
	public Transform objectToAim;

	//jet pack related stuff
	public float jetPackFuel = 1000f;
	public float jetPackFuelMax = 1000f;
	public float jetPackFuelReplenishRate = 0.5f;

	public GameObject jetPackFlamesGO;

	//references to components
	private Animator anim;
	private Rigidbody rigid;

	//aiming variables
	private float yaw = 0.0f;
	private float pitch = 0.0f;

	//simple bools to check for stuff
	private bool isJumping = false;
	private bool isJetpacking = false;

	//jumping related variables
	private float groundDistance = 0.5f;
	private float groundedTimerMax = 1f;
	private float groundedTimer = 0f;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		rigid = gameObject.GetComponent<Rigidbody> ();

		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		movement ();

		jump ();

		aiming ();

		jetPack ();
	}

	void aiming()
	{
		//calculate the aim position
		yaw += aimSpeed * Input.GetAxis ("Mouse X");
		pitch += aimSpeed * Input.GetAxis ("Mouse Y");

		float finalPitch = pitch;
		// //Debug.Log("finalPitch" + finalPitch);

		//limit the cabin rotation on z axis
		if (pitch > 20f) {
			finalPitch = 20f;
		} else if (pitch < -20f) {
			finalPitch = -20f;
		}
			
		//apply the calculation to the acutal object
		objectToAim.transform.eulerAngles = new Vector3 (0, yaw, finalPitch * -1);
	}

	void movement()
	{
		int moveSpeed = movementSpeed;

		anim.speed = 1f;

		//handle sprinting
		if (Input.GetKey (KeyCode.LeftShift)) {
			anim.speed = 3f;
			moveSpeed = movementSpeed + 5;
		}

		//movement forward
		if (Input.GetKey (KeyCode.W)) {
			//animator params
			anim.SetInteger ("speed", 1);

			//move position
			transform.position += (transform.rotation * Vector3.left) * moveSpeed * Time.deltaTime;
		}
			
		//movement back
		if (Input.GetKey (KeyCode.S)) {
			anim.SetInteger ("speed", -1);
			transform.position -= (transform.rotation * Vector3.left) * movementSpeed * Time.deltaTime;
		}

		//robot rotation left, rotates the base of the model and the forward code handles the actual movement
		if (Input.GetKey (KeyCode.A)) {
			transform.rotation *= Quaternion.Euler (new Vector3 (0f, -robotRotationSpeed, 0f));
			anim.SetInteger ("turning", 1);
		}

		//robot rotation right, rotates the base of the model and the forward code handles the actual movement
		if (Input.GetKey (KeyCode.D)) {
			transform.rotation *= Quaternion.Euler (new Vector3 (0f, robotRotationSpeed, 0f));
			anim.SetInteger ("turning", -1);
		}


		//stop moving forward
		if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetInteger ("speed", 0);
		}
		//stop moving backwards
		if (Input.GetKeyUp (KeyCode.S)) {
			anim.SetInteger ("speed", 0);
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetInteger ("turning", 0);
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			anim.SetInteger ("turning", 0);
		}
	}

	void jump()
	{
		// //Debug.Log (isGrounded ());

		if (Input.GetKeyDown (KeyCode.Space)) {
			//Debug.Log ("Jumped");
		}

		//check if p;ayer is on the ground and if they pressed space
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
			anim.SetBool ("jump", true);
			rigid.velocity = Vector3.up * jumpSpeed;
			isJumping = true;
		}

		//if player is currently jumping
		if (isJumping) {
			groundedTimer += Time.deltaTime;

			//wait a few seconds
			if (groundedTimer >= groundedTimerMax) {
				groundedTimer = 0f;

				//check if the player is on the ground and stop the animation
				if (isGrounded ()) {
					anim.SetBool ("jump", false);
					isJumping = false;
				}
			}
		}
	}

	void jetPack()
	{
		//get button press for jetpack and check that there is some fuel
		if (Input.GetKey (KeyCode.V) && jetPackFuel > 0) {
			//add force to rigidbody
			rigid.AddForce (Vector3.up * 12000);
			//do fuel calculation
			jetPackFuel -= 10;


			jetPackFlames (true);


		} else {
			//if we not using the jet pack replenish the fuel
			if (jetPackFuel < jetPackFuelMax) {
				jetPackFuel += jetPackFuelReplenishRate;
			}

			jetPackFlames (false);
		}
	}

	void jetPackFlames(bool onoff)
	{
		foreach (Transform trans in jetPackFlamesGO.transform) {

			var sys = trans.gameObject.GetComponent<ParticleSystem> ();
			//Debug.Log (sys);
			if (onoff) {
				sys.Play ();
			} else {
				sys.Stop ();
			}
		}

	}

	//fire a ray cast to check if there is ground beneith the player
	//this would probably benefit from firing a couple of ray casts because the payer base is quite big and might be over an edge
	bool isGrounded() {
		return Physics.Raycast (transform.position, -Vector3.up, groundDistance + 0.1f);
	}
}
