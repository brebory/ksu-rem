using UnityEngine;
using System.Collections;

public class InputBroadcaster : MonoBehaviour {

	private bool paused;

	// Use this for initialization
	void Start() {
		paused = false;
		Messenger.AddListener("GamePause", OnGamePause);
		Messenger.AddListener("GameResume", OnGameResume);
	}
	
	// Update is called once per frame
	void Update() {
		if (!paused) {
			if (Input.GetKey(KeyCode.Q)) {
				Messenger.Broadcast("InputAttackEvent1");
			}

			if (Input.GetKey(KeyCode.W)) {
				Messenger.Broadcast("InputAttackEvent2");
			}

			if (Input.GetKey(KeyCode.E)) {
				Messenger.Broadcast("InputAttackEvent3");
			}

			if (Input.GetKey(KeyCode.R)) {
				Messenger.Broadcast("InputAttackEvent4");
			}

			if (Input.GetKey(KeyCode.Space)) {
				Messenger.Broadcast("InputAttackComboEvent");
			}
		}
	}

	void OnGamePause() {
		paused = true;
	}

	void OnGameResume() {
		paused = false;
	}
}
