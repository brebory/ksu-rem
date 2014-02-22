using UnityEngine;
using System.Collections;

public class AttackControl : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {

		// Cache and store player object
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");

		// Register event listeners
		Messenger.AddListener("InputAttackEvent1", OnInputAttackEvent1);
		Messenger.AddListener("InputAttackEvent2", OnInputAttackEvent2);
		Messenger.AddListener("InputAttackEvent3", OnInputAttackEvent3);
		Messenger.AddListener("InputAttackEvent4", OnInputAttackEvent4);
		Messenger.AddListener("InputAttackComboEvent", OnInputAttackComboEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Gets the current cursor's scene position using Camera.ScreenPointToRay and Physics.Raycast
	/// </summary>
	/// <returns>The scene position.</returns>
	public Vector3 GetScenePosition() {
		// Return a new transform at the point of the mouse click, on the same level as the player
		Vector3 result;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			result = hit.point;
			result.y = player.transform.position.y;
		} else {
			result = Vector3.zero;
		}
		Debug.Log(result);
		return result;
	}

	void OnInputAttackEvent1() {
		IAttackSpell fireSpell = new FireSpell(GetScenePosition());
		Debug.Log(fireSpell.GetPosition());
		player.GetComponent<weaponScript>().FireWeapon(fireSpell);
	}

	void OnInputAttackEvent2() {
		IAttackSpell waterSpell = new WaterSpell(GetScenePosition());
		player.GetComponent<weaponScript>().FireWeapon(waterSpell);
	}

	void OnInputAttackEvent3() {
		IAttackSpell earthSpell = new EarthSpell(GetScenePosition());
		player.GetComponent<weaponScript>().FireWeapon(earthSpell);
	}

	void OnInputAttackEvent4() {
		IAttackSpell windSpell = new WindSpell(GetScenePosition());
		player.GetComponent<weaponScript>().FireWeapon(windSpell);
	}

	void OnInputAttackComboEvent() {
		Debug.Log("Combo Event Pressed!");
	}
}
