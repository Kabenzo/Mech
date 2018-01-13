using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	PlayerManager playerManager;

	//Ship Stats
	float PHealth;
	float PSpeed;
	float PFuel;
	float PRotSpeed;
	float PMaxSpeed;
	float PAccel;
	float PMaxFuel;

	float currentSpeed;

	//UI Elements
	public Text text;
	public Text fuel;
	public Text health;

	Rigidbody2D rbody;

	void Start () {
		playerManager = GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ();
		rbody = GetComponent<Rigidbody2D> ();

		PHealth = playerManager.health;
		PSpeed = playerManager.speed;
		PFuel = playerManager.fuel;
		PRotSpeed = playerManager.rotSpeed;
		PMaxSpeed = playerManager.maxSpeed;
		PAccel = playerManager.acceleration;
		PMaxFuel = playerManager.maxFuel;
	}
	

	void Update () {
		
		//Rotation
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * PRotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		//Speed Manager


		if (Input.GetKey (KeyCode.W)) {
			currentSpeed += PAccel * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			currentSpeed-= PAccel * Time.deltaTime;
		}
		currentSpeed = Mathf.Clamp (currentSpeed, 0f, PMaxSpeed); 


		//Forward Speed
		if (PFuel > 0) {
			rbody.AddForce (transform.up * PSpeed * currentSpeed);
		}

		//Fuel Manager
		PFuel = PFuel - currentSpeed * Time.deltaTime;
		PFuel = Mathf.Clamp (PFuel, 0f, PMaxFuel); 


		//UI
		text.text = "Speed: " + currentSpeed.ToString();
		fuel.text = "Fuel: " + PFuel.ToString ();
		health.text = "Health: " + PHealth.ToString ();
		
	}
}
