using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {

	public int faction;

	// Use this for initialization
	void Start () {
		faction = Random.Range (0, 3);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
