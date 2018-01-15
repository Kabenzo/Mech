using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairBehav : MonoBehaviour {

	Camera cam;


	void Start () {
		cam = Camera.main;
	}

	void Update () {
		var mousePos = Input.mousePosition;
		mousePos.z = 10;
		transform.position = cam.ScreenToWorldPoint (mousePos);

	}
}
