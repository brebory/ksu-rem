using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Level Changing
	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			switch (Application.loadedLevelName){
				case "First":
					Application.LoadLevel("Second");
					break;
				case "Second":
					Application.LoadLevel("Third");
					break;
				case "Third":
					Application.LoadLevel("Fourth");
					break;
				default:
					Debug.Log("Error Changing Level");
					break;
			}
		}
	}
}
