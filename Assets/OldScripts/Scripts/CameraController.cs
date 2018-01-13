using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;       


	private Vector3 offset;
	public float minZoom = 0.5f;
	public float maxZoom = 30f;

	// Use this for initialization
	void Start ()
	{
		
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () 
	{
		if (Camera.main.orthographicSize >= minZoom && Camera.main.orthographicSize <= maxZoom) {
			Camera.main.orthographicSize = Camera.main.orthographicSize - Input.GetAxis ("Mouse ScrollWheel");
			transform.position = player.transform.position + offset;

		}

		if (Camera.main.orthographicSize < minZoom) {
			Camera.main.orthographicSize = minZoom;
		}

		if (Camera.main.orthographicSize > maxZoom) {
			Camera.main.orthographicSize = maxZoom;
		}
	}
}