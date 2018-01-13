using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public Transform target;

	private Rigidbody2D rbody;

	[Header("Attributes")]

	public float range = 10f;
	public float turnSpeed;
	public float fireRate = 1f;
	private float fireCountDown = 0f;
	public float shootForce;
	public Transform bullet;
	public Transform firePoint;
	public float ammo = 30f;
	public float speed;



	[Header("Unity Setup Fields")]

	public string enemyTag = "B";



	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		//InvokeRepeating ("UpdateTarget", 0f, 0.5f);	

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
			UpdateTarget ();
			return;

		}

			Vector2 dir = new Vector2 (target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
			float rot = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90f;
			Quaternion goalRot = Quaternion.Euler (0, 0, rot);
			transform.rotation = Quaternion.Lerp (transform.rotation, goalRot, turnSpeed * Time.deltaTime); 
		
			

		if (fireCountDown <= 0f) {
				Shoot ();
				fireCountDown = 1f / fireRate;

		}

		fireCountDown -= Time.deltaTime;


		if ((transform.position - target.transform.position).magnitude >= 2){

		rbody.AddForce (transform.up * speed);

	}
	}

	void Shoot(){
		Debug.Log ("Shoot");
		Transform laser = Instantiate (bullet, firePoint.position, transform.rotation); 
		laser.GetComponent<Rigidbody2D> ().AddForce (laser.transform.up * shootForce);
		ammo--;

	}
		
	//void OnDrawGizmosSelected (){
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawWireSphere (transform.position, range);
	//}
}
