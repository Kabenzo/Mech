using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public PlayerManager playerManager;
	public Item primaryWeapon;
	public Item secondaryWeapon;

	//Ship Stats
	float PHealth;
	float PSpeed;
	float PRotSpeed;
	float PMaxSpeed;
	float PAccel;
	float PAmmo;
	float SAmmo;

	public float currentSpeed;

	//UI Elements
	public Text text;
	public Text health;
	public Text pAmmo;

	Rigidbody2D rbody;

	//Other
	public bool isShooting = false;
	public Attack attack;

	//Weapon
	public GameObject primaryProjectile;
	public GameObject secondaryProjectile;
	public float PrimaryFireRate;
	public float SecondaryFireRate;
	public float PrimaryFireSpeed;
	public float SecondaryFireSpeed;

	public Transform leftHand;
	public Transform rightHand;



	void Start () {
		playerManager = GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ();
		rbody = GetComponent<Rigidbody2D> ();
		attack = GetComponent<Attack> ();

		primaryWeapon = playerManager.leftWeapon;
		secondaryWeapon = playerManager.rightWeapon;

		//Stats
		PHealth = playerManager.health;
		PSpeed = playerManager.speed;
		PRotSpeed = playerManager.rotSpeed;
		PMaxSpeed = playerManager.maxSpeed;
		PAccel = playerManager.acceleration;
		PAmmo = primaryWeapon.ammo;
		SAmmo = secondaryWeapon.ammo;

	

		//Weapons
		primaryProjectile = primaryWeapon.projectile;
		secondaryProjectile = secondaryWeapon.projectile;
		PrimaryFireSpeed = primaryWeapon.fireSpeed;
		PrimaryFireRate = primaryWeapon.fireRate;
		SecondaryFireSpeed = secondaryWeapon.fireSpeed;
		SecondaryFireRate = secondaryWeapon.fireRate;

	}
	

	void Update () {
		
		//Rotation
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * PRotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		//Speed Manager
		 

		currentSpeed = PSpeed * Input.GetAxis ("Vertical");
		currentSpeed = Mathf.Clamp (currentSpeed, -PMaxSpeed, PMaxSpeed); 

		//Ammo Clamp
		PAmmo = Mathf.Clamp (PAmmo,0f, primaryWeapon.ammo);
		SAmmo = Mathf.Clamp (SAmmo,0f, secondaryWeapon.ammo);

		//UI
		text.text = "Speed: " + currentSpeed.ToString();
		health.text = "Health: " + PHealth.ToString ();

		if (attack.currentGunId == 1) {
			pAmmo.text = primaryWeapon.name + ": " + PAmmo.ToString ();
		}

		if (attack.currentGunId == 2) {
			pAmmo.text = secondaryWeapon.name + ": " + SAmmo.ToString ();

		}

	
	}

	void FixedUpdate () {
		//Forward Speed
			rbody.AddForce (transform.up * currentSpeed);
		

	}

	public IEnumerator UseAttack () {
		//There is a bug, where when two guns have slow fire rate and you spam them, occasionally one gun will fire twice

		if (isShooting == false) {
			isShooting = true;

			//Fire Primary Weapon
			if (attack.currentGunId == 1 && PAmmo > 0)  {
				GameObject bullet = Instantiate (primaryProjectile, leftHand.position, leftHand.rotation);
				bullet.GetComponent<Rigidbody2D> ().AddForce (bullet.transform.up * PrimaryFireSpeed);
				yield return new WaitForSeconds (PrimaryFireRate);
				PAmmo--;
				isShooting = false;
			}
			//Fire Secondary Weapon
			if (attack.currentGunId == 2 && SAmmo > 0) {
				GameObject bullet = Instantiate (secondaryProjectile, rightHand.position, rightHand.rotation);
				bullet.GetComponent<Rigidbody2D> ().AddForce (bullet.transform.up * SecondaryFireSpeed);
				yield return new WaitForSeconds (SecondaryFireRate);
				SAmmo--;
				isShooting = false;
			} else if (isShooting == true) {
				isShooting = false;
			}



		}
	}
}
