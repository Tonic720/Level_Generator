using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

	public LevelGenerator gen1;
	public LevelGenerator gen2;
	public LevelGenerator gen3;
	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gen1.counter == 75 && gen2.counter == 75 && gen3.counter == 75) {
			//EditorSceneManager.LoadScene ("Generator");
			text.text = "PRESS R to Restart";

			if(Input.GetKey(KeyCode.R)){
				
				SceneManager.LoadScene("Generator");
			}
		}
	}
}
