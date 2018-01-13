using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHealthManager : MonoBehaviour {

	public int health;
	private int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = health;
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}

	}

	public void HurtFriendly(int damage){
		currentHealth -= damage;
	}

}
