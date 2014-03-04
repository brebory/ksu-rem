/*
 * 
 *  Authors: Brendon Roberto
 *  Project: Project REM
 *  Date: 1/30/2013
 * 
 */

using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyVisionBehavior : MonoBehaviour, IVisionEntity 
{

	// Use this for initialization
	void Start () {
		// dummy
	}
	
	// Update is called once per frame
	void Update () {
		// dummy
	}

	public bool CheckLOS(GameObject target) {
		// Line of sight is clear if we can cast a ray between this position and the target's position.
		if (target) {
			bool result;
			RaycastHit hitInfo;

			// Calculate vector from this position to target.
			Vector3 targetDirection = target.transform.position - this.transform.position;

			// Use Physics.RayCast to check if there's a clear LOS to target's position.
			Physics.Raycast(this.transform.position, targetDirection, out hitInfo);

			// Check that the collider was the target, and that the direction angle is smaller than the angle of view.
			if (hitInfo.collider) {
				result = hitInfo.collider.gameObject == target.gameObject;
			} else {
				result = false;
			}
			result = result && (Mathf.Abs(Vector3.Angle(this.transform.forward, targetDirection)) < GetAngleOfView());
			return result;
		} else {
			return false;
		}
	}

	public bool CheckVisionRadius(GameObject target) {
		// Check that the distance between this object and the target is less than the visionRadius
		if (target) {
			return VectorUtils.Distance(this.transform.position, target.transform.position) < GetVisionRadius();;
		} else {
			return false;
		}
	}

	public bool CheckVisible(GameObject target) {
		// If the target is both within Vision Radius, and Line of Sight, then it is visible.
		if (target) {
			return this.CheckVisionRadius(target) && this.CheckLOS(target);
		} else {
			return false;
		}
	}

	public List<GameObject> GetVisibleObjects() {
		List<GameObject> result = new List<GameObject>();

		// Use Physics.OverlapSphere to get a list of all hits within vision radius.
		Collider[] collisions = Physics.OverlapSphere(this.transform.position, (float)GetVisionRadius());
		foreach (Collider collider in collisions) {
			if(CheckVisible(collider.gameObject)) {
				result.Add(collider.gameObject);
			}
		}
		return result;
	}

	abstract public double GetVisionRadius();

	abstract public double GetAngleOfView();
}
