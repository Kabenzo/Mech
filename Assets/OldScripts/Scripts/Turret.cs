using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform target;


	[Header("Attributes")]

	public float range = 10f;
	public float turnSpeed;
	public float fireRate = 1f;
	private float fireCountDown = 0f;
	public float shootForce;
	public Transform bullet;
	public Transform firePoint;
	public float ammo = 30f;



	[Header("Unity Setup Fields")]

	public string enemyTag = "B";



	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);	

		if (gameObject.tag == "A") {
			enemyTag = "B";
		}

		if (gameObject.tag == "B") {
			enemyTag = "A";
		}
	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector2.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		}
		else {
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;

		
		} 

		Vector2 dir = new Vector2 (target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
		float rot = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		Quaternion goalRot = Quaternion.Euler (0, 0, rot);
		transform.rotation = Quaternion.Lerp (transform.rotation, goalRot, turnSpeed * Time.deltaTime); 


		if (fireCountDown <= 0f) {
			if (ammo >= 1f) {
				Shoot ();
				fireCountDown = 1f / fireRate;
			} else if (ammo <= 0f) {
				StartCoroutine (reload ());
			}
		}

		fireCountDown -= Time.deltaTime;
		
	}

	void Shoot(){
		Debug.Log ("Shoot");
		Transform laser = Instantiate (bullet, firePoint.position, transform.rotation); 
		laser.GetComponent<Rigidbody2D> ().AddForce (laser.transform.up * shootForce);
		ammo--;

	}

	IEnumerator reload(){
		yield return new WaitForSeconds (3f);
		ammo = 30;
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
