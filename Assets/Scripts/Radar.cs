using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	private CircleCollider2D radar;
	private MultipleTargetCamera cam;

	void Start () {
		radar = GetComponent<CircleCollider2D> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MultipleTargetCamera> ();
		radar.radius = 6f;
	}
		

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Enemy") {
			Debug.Log ("Add to list");
			cam.targets.Add (col.transform);
		}
	}

	void OnTriggerExit2D (Collider2D col) {

		if (col.tag == "Enemy") {
			Debug.Log ("Remove  list");
			cam.targets.Remove (col.transform);
		}
	}
}
