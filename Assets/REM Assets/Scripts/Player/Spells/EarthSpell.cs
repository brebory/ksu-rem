using UnityEngine;
using System.Collections;

public class EarthSpell : IAttackSpell {

	private Vector3 _position;

	public EarthSpell(Vector3 position) {
		_position = position;
	}

	public Vector3 GetPosition() {
		return _position;
	}

	/// <summary>
	/// Factory method to create an EarthSpell prefab.
	/// </summary>
	/// <returns>The prefab.</returns>
	public GameObject GetPrefab() {
		GameObject prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		prefab.AddComponent<SphereCollider>();
		prefab.AddComponent<projectileScript>();
		prefab.renderer.material.color = Color.green;
		return prefab;
	}
}
