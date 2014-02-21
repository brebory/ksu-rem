using UnityEngine;
using System.Collections;

public class AttackControl : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {

		// Cache and store player object
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
		Messenger.AddListener("InputAttackEvent1", OnInputAttackEvent1);
		Messenger.AddListener("InputAttackEvent2", OnInputAttackEvent2);
		Messenger.AddListener("InputAttackEvent3", OnInputAttackEvent3);
		Messenger.AddListener("InputAttackEvent4", OnInputAttackEvent4);
		Messenger.AddListener("InputAttackComboEvent", OnInputAttackComboEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnInputAttackEvent1() {

	}

	void OnInputAttackEvent2() {

	}

	void OnInputAttackEvent3() {

	}

	void OnInputAttackEvent4() {

	}

	void OnInputAttackComboEvent() {

	}
}
