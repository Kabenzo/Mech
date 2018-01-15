using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour {

	Transform target;
	float turnSpeed = 10f;
	//public Item primaryItem;


	void Start () {
		//turnSpeed = primaryItem.turnSpeed;
		target = GameObject.FindGameObjectWithTag ("Crosshair").transform;
	}

	void Update () {
		Vector2 dir = new Vector2 (target.position.x - gameObject.transform.position.x, target.position.y - gameObject.transform.position.y);
		float rot = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		Quaternion goalRot = Quaternion.Euler (0, 0, rot);
		transform.rotation = Quaternion.Lerp (transform.rotation, goalRot, turnSpeed * Time.deltaTime); 
	}
}
