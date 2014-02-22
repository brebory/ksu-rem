using UnityEngine;
using System.Collections;

public class WaterSpell : IAttackSpell {

	private string name = "Water Spell";
	private Vector3 _position;

	public WaterSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	public string GetSpellName() {
		return name;
	}
}
