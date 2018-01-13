using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEntity : MonoBehaviour {

	public int damageToGive;

	public void OnCollisionEnter2D (Collision2D other)
	{

		if (gameObject.tag == "FrBul") {
			

			if (other.gameObject.tag == "B") {
				other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
				Destroy (gameObject);
			}

		}
		if (gameObject.tag == "EnBul") {

			if (other.gameObject.tag == "A") {
				other.gameObject.GetComponent<FriendlyHealthManager> ().HurtFriendly (damageToGive);
				Destroy (gameObject);
			}
		}

			
	}
}