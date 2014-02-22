using UnityEngine;
using System.Collections;

public class EarthSpell : IAttackSpell {

	private string name = "Earth Spell";
	private Vector3 _position;

	public EarthSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	public string GetSpellName() {
		return name;
	}
}
