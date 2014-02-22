using UnityEngine;
using System.Collections;

public class WindSpell : IAttackSpell {

	private Vector3 _position;

	public WindSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	/// <summary>
	/// Factory method to create a WindSpell prefab.
	/// </summary>
	/// <returns>The prefab.</returns>
	public GameObject GetPrefab() {
		GameObject prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		prefab.AddComponent<SphereCollider>();
		prefab.AddComponent<projectileScript>();
		prefab.renderer.material.color = Color.cyan;
		return prefab;
	}
}
