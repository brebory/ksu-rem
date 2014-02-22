using UnityEngine;
using System.Collections;

public class WaterSpell : IAttackSpell {

	private Vector3 _position;

	public WaterSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	/// <summary>
	/// Factory method to create a WaterSpell prefab.
	/// </summary>
	/// <returns>The prefab.</returns>
	public GameObject GetPrefab() {
		GameObject prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		prefab.AddComponent<SphereCollider>();
		prefab.AddComponent<projectileScript>();
		prefab.renderer.material.color = Color.blue;
		return prefab;
	}
}
