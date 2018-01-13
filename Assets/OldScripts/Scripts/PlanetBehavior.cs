using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetBehavior : MonoBehaviour {

	public GameObject star;

	public float distance;
	public float angle;
	//public float velocity;
	public int planetType;
	public SpriteRenderer sprite;
	public GameObject player;
	public Sprite Type1;
	public Sprite Type2;
	public Sprite Type3;
	public int habitability;
	//0 = republic, 1 = fascists, 2 = rebels
	public string[] nameArray;
	public string[] republicNames;
	public string[] fascistNames;
	public string [] rebelNames;
	public string planetName;
	public StarBehavior behav;



	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		player = GameObject.Find ("Player(Clone)");
		planetType = (Random.Range (1, 4));
		star = GameObject.FindGameObjectWithTag ("Star");
		Debug.Log (planetType);
		transform.SetParent (star.transform);

		if (planetType == 1) 
		{
		distance = (Random.Range(10f, 25f));
		//velocity = (Random.Range(0.005f,0.01f));
		angle = (Random.Range(0f,6f));
		sprite.sprite = Type1;
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f));
		habitability = Random.Range(0,2);
			if (habitability == 1) {


				if (behav.faction == 0) {
					planetName = republicNames[Random.Range(0,republicNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];

				}
				if (behav.faction == 1) {
					planetName = fascistNames[Random.Range(0,fascistNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];

				}
				if (behav.faction == 2) {
					planetName = rebelNames[Random.Range(0,rebelNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];

				}


			}


		}
		if (planetType == 2) 
		{
		distance = (Random.Range(40f, 65f));
		//velocity = (Random.Range(0.002f,0.007f));
		angle = (Random.Range(0f,6f));
		sprite.sprite = Type2;
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f));
		habitability = Random.Range (0, 2);

			if (habitability == 1) {


				if (behav.faction == 0) {
					planetName = republicNames[Random.Range(0,republicNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];
					
				}
				if (behav.faction == 1) {
					planetName = fascistNames[Random.Range(0,fascistNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];

				}
				if (behav.faction == 2) {
					planetName = rebelNames[Random.Range(0,rebelNames.Length)] + nameArray[Random.Range(0,nameArray.Length)];

				}
					

			}
		
		


		}
		if (planetType == 3) 
		{
		distance = (Random.Range(55f, 75f));
		//velocity = (Random.Range(0.0005f,0.001f));
		angle = (Random.Range(0f,6f));
		sprite.sprite = Type3;
		habitability = 0;
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f), Random.Range (0.50f, 0.255f));
		
		
		}

		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.X) && player.transform.position.x <= transform.position.x + 1.2 && player.transform.position.x>= transform.position.x -1.2 && player.transform.position.y <= transform.position.y + 1.2 && player.transform.position.y>= transform.position.y -1.2) {

			Debug.Log ("Land");
			//SceneManager.LoadScene ("Intro", LoadSceneMode.Single);

		}

			
		transform.position = new Vector3 (Mathf.Cos (angle) * distance + star.transform.position.x, Mathf.Sin (angle) * distance + star.transform.position.y, 0f); 
		//angle = angle + velocity * Time.deltaTime;

	}
}
