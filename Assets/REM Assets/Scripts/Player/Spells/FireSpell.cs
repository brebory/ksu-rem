using UnityEngine;
using System.Collections;

public class FireSpell : IAttackSpell {

	private string name = "Fire Spell";
	private Vector3 _position;

	public FireSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	public string GetSpellName() {
		return name;
	}
}
