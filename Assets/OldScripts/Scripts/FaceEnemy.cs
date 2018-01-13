using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceEnemy : MonoBehaviour {

	public float turnSpeed = 5f;

	GameObject locked;

	public bool targetLock = false;

	public Transform bullet;

	public bool isFiring = false;

	public Transform firePoint;
	public float shootForce;
	public float shootRadius;

	public int ammo = 30;




	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		//Debug.DrawRay (transform.position,forward,Color.green,5f,false);


		if (locked == null) {

			if (targetLock == false) {

				if (gameObject.tag == "A") {
					foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("B")) {
						if ((transform.position - enemy.transform.position).magnitude <= shootRadius) {

							locked = enemy;
							break;
						}

					}

				}

				if (gameObject.tag == "B") {
					//enemy = GameObject.FindGameObjectWithTag ("A");
				
				}


			}
				

		} else if (locked != null) {

			targetLock = true;
		}

		if (targetLock == true) {
		
			//if (enemy.transform.position.x <= transform.position.x + 5f && enemy.transform.position.y <= enemy.transform.position.y + 5f) 
			if ((transform.position - locked.transform.position).magnitude <= shootRadius) {
				Vector2 dir = new Vector2 (locked.transform.position.x - gameObject.transform.position.x, locked.transform.position.y - gameObject.transform.position.y);
				float rot = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90f;
				Quaternion goalRot = Quaternion.Euler (0, 0, rot);
				transform.rotation = Quaternion.Lerp (transform.rotation, goalRot, turnSpeed * Time.deltaTime); 

				if (ammo >= 1) {

					if (isFiring == false) {
						StartCoroutine (fire ());

					}
				}

				else if(ammo<=0){
					if (isFiring == false) {
						StartCoroutine (reload ());

					}

				}

			} else {
				locked = null;
				targetLock = false;
			}

		}

	}

	IEnumerator fire(){
		isFiring = true;
		yield return new WaitForSeconds (0.1f);
		Transform laser = Instantiate (bullet, firePoint.position, transform.rotation); 
		laser.GetComponent<Rigidbody2D> ().AddForce (laser.transform.up * shootForce); 
		ammo--;
		isFiring = false;

	}

	IEnumerator reload(){
		isFiring = true;
		yield return new WaitForSeconds (3f);
		ammo = 30;
		isFiring = false;

	}
}
