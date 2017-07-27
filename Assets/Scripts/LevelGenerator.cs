using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour {
	public GameObject[] tiles;
	public GameObject wall;
	public int test = 0;


	public float chanceUp;
	public float chanceRight;
	public float chanceLeft;
	public int counter = 0;

	public LevelGenerator otherGen;
	public LevelGenerator otherGen2;


		


	public List<Vector3> createdTiles;

	public int tileAmount;
	public int tileOffset;

	public float waitTime;
	// Use this for initialization
	void Start () {
		StartCoroutine (GenerateLevel());

		// if you want to create the same level every time use this 
		//Random.seed = 10;


	}


	IEnumerator GenerateLevel(){


		for(int i = 0; i < tileAmount; i++){
			
			float dir = Random.Range(0f,1f);
			int tile = Random.Range (0, tiles.Length);

			CallMoveGen (dir);
			CreateTile (tile);

			yield return new WaitForSeconds (waitTime);
			
		}

		yield return 0;
	}

	void CallMoveGen(float ranDir){

		if (ranDir < chanceUp) {
			MoveGen (0);
		} else if (ranDir < chanceRight) {
			MoveGen (1);
		} else if (ranDir < chanceLeft) {
			MoveGen (2);
		} else {
			MoveGen (3);
		}
	}

	void MoveGen(int dir){


		switch(dir){

		case 0:
			transform.position = new Vector3 (transform.position.x, transform.position.y + tileOffset, 0);
			break;
		
		
		case 1:
			transform.position = new Vector3 (transform.position.x + tileOffset, transform.position.y, 0);
			break;

		case 2:
			transform.position = new Vector3 (transform.position.x, transform.position.y - tileOffset, 0);
			break;

		case 3:
			transform.position = new Vector3 (transform.position.x - tileOffset, transform.position.y, 0);
			break;







		}


	}

	void CreateTile(int tileIndex){

		if (!createdTiles.Contains (transform.position) && !otherGen.createdTiles.Contains(transform.position)
			&& !otherGen2.createdTiles.Contains(transform.position)) {
			GameObject tileObject;

			tileObject = Instantiate (tiles [tileIndex], transform.position, transform.rotation) as GameObject;

			createdTiles.Add (tileObject.transform.position);
			counter++;

			
		}else{
			tileAmount++;
		}


	}
	

}
