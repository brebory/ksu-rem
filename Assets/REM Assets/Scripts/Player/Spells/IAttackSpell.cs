using UnityEngine;
using System.Collections;

/// <summary>
/// IAttackSpell is an interface class for other spells to implement. Always use IAttackSpell rather than a specific Spell class when working with spells.
/// </summary>
public interface IAttackSpell {
	
	Vector3 GetPosition();
}
