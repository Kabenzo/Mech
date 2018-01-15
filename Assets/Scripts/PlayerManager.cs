using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Item leftWeapon;
	public Item rightWeapon;
	
	public float health;
	public float speed; 
	public float rotSpeed;
	public float maxSpeed;
	public float acceleration;

	void Awake (){
		DontDestroyOnLoad (this.gameObject);
		health = 10f;
		speed = 50f;
		rotSpeed = 180f;
		maxSpeed = 50f;
		acceleration = 15;


	}

	void Start () {
		
		
	}
		
}
