using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
	
	public float health;
	public float fuel;
	public float speed; 
	public float rotSpeed;
	public float maxSpeed;
	public float acceleration;
	public float maxFuel;

	void Awake (){
		DontDestroyOnLoad (this.gameObject);

	}

	void Start () {
		health = 10f;
		maxFuel = 5000f;
		fuel = maxFuel;
		speed = 5f;
		rotSpeed = 180f;
		maxSpeed = 50f;
		acceleration = 15;

		/* Further ideas include:
		 * Armor
		 * Attack
		 * Etc
		 */
		
	}
		
}
