using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns;
	public int rows;
	public Count PlanetCount = new Count (6,13);
	//public Count tbdCount = new Count (min, max);
	public GameObject wormhole;
	public GameObject player;
	public GameObject[] spaceTiles;
	//public GameObject[] outerWallTiles;
	//public GameObject[] content;
	public GameObject[] planets;
	public GameObject star;

	private Transform organizer;
	private List <Vector3> gridPositions =  new List<Vector3>();

	void InitialiseList(){
		gridPositions.Clear();

		for (int x = 1; x < columns; x++) 
		{
			for (int y = 1; y < rows; y++) 
			{

				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void BoardSetup()
	{
		organizer = new GameObject ("Space").transform;

		for (int x = 1; x < columns; x++) 
		{
			for (int y = 1; y < rows; y++) 
			{
				GameObject toInstantiate = spaceTiles [Random.Range (0, spaceTiles.Length)];

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;


				instance.transform.SetParent (organizer);
			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range(0,gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1);

		for (int i = 0; i < objectCount; i++) 
		{
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);

		}

	}


	public void SetUpScene (int level)
	{
		BoardSetup ();
		InitialiseList ();
		Instantiate(wormhole, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
		Instantiate (player, new Vector3 (columns / 2, rows / 2, 0f), Quaternion.identity);
		Instantiate (star, new Vector3 (columns / 2, rows / 2, 0f), Quaternion.identity);
		//LayoutObjectAtRandom(planets, PlanetCount.maximum, PlanetCount.minimum);
	}


}
