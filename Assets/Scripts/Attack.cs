using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public PlayerMovement playerMovement;
	public int currentGunId = 1;

	void Start () {
		playerMovement = GetComponent<PlayerMovement> ();
	}

	void Update () {

		if (Input.GetMouseButton (0) && !Input.GetMouseButton(1)) {
			currentGunId = 1;
			StartCoroutine (playerMovement.UseAttack ());
		}

		if (Input.GetMouseButton (1) && !Input.GetMouseButton (0)) {
			currentGunId = 2;
			StartCoroutine (playerMovement.UseAttack ());

		} 

	
		

	}
}
