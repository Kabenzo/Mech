using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float maxSpeed = 5f;

	public Transform shootPoint;
	public Transform playerBullet;

	public float shootForce = 300f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;

	float rotSpeed = 180f;

	Rigidbody2D rbody;

	void Start(){

		rbody = GetComponent<Rigidbody2D> ();

	}

	void Update()
	{
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;


		rbody.AddForce(transform.up * maxSpeed * Input.GetAxis("Vertical"));

	
		if (rbody.velocity.magnitude > maxSpeed) {

			rbody.velocity = rbody.velocity.normalized * maxSpeed;
		}

		if (Input.GetButton ("Space")) {
			if (fireCountDown<=0f) {
				shoot();
				fireCountDown = 1f / fireRate;
			}

		}
			fireCountDown -= Time.deltaTime;
		

	}


	void shoot(){
		Transform laser = Instantiate (playerBullet, shootPoint.position, transform.rotation); 
		laser.GetComponent<Rigidbody2D> ().AddForce (laser.transform.up * shootForce); 


	}
}
