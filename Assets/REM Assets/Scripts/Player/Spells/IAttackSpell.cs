using UnityEngine;
using System.Collections;

/// <summary>
/// IAttackSpell is an interface class for other spells to implement. Always use IAttackSpell rather than a specific Spell class when working with spells.
/// </summary>
public interface IAttackSpell {

	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <returns>The position.</returns>
	Vector3 GetPosition();

	/// <summary>
	/// Factory method to construct the appropriate projectile Prefab for the Spell.
	/// </summary>
	/// <returns>The prefab.</returns>
	GameObject GetPrefab();
}
