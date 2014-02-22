using UnityEngine;
using System.Collections;

public class WindSpell : IAttackSpell {

	private string name = "Wind Spell";
	private Vector3 _position;

	public WindSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	public string GetSpellName() {
		return name;
	}
}
