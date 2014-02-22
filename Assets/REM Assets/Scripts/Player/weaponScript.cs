using UnityEngine;
using System.Collections;

public class weaponScript : MonoBehaviour 
{
	// public
	public float projMuzzleVelocity; 
	public GameObject projPrefab;
	public float RateOfFire;
	public float Inaccuracy;
	
	// private
	private float fireTimer;
	
	// Use this for initialization
	void Start () 
	{
		fireTimer = Time.time + RateOfFire;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
			if (Time.time > fireTimer)
			{
				GameObject projectile;
				Vector3 muzzlevelocity = transform.forward;
				
				if (Inaccuracy != 0)
				{
					Vector2 rand = Random.insideUnitCircle;
					muzzlevelocity += new Vector3(rand.x, rand.y, 0) * Inaccuracy;
				}
				
				muzzlevelocity = muzzlevelocity.normalized * projMuzzleVelocity;
				
				projectile = Instantiate(projPrefab, transform.position, transform.rotation) as GameObject;
				projectile.GetComponent<projectileScript>().muzzleVelocity = muzzlevelocity;
				fireTimer = Time.time + RateOfFire;
			}
			else
				return;
		}
	}
	
	public void FireWeapon(IAttackSpell spell)
	{
		// Dummy animation
		if (Time.time > fireTimer)
		{
			GameObject projectile;
			// Create velocity vector to spell position
			Vector3 muzzlevelocity = spell.GetPosition() - transform.position;

			Debug.Log(muzzlevelocity);
			Debug.DrawLine(transform.position, spell.GetPosition(), Color.red, 5.0f, false);
			
			if (Inaccuracy != 0)
			{
				Vector2 rand = Random.insideUnitCircle;
				muzzlevelocity += new Vector3(rand.x, rand.y, 0) * Inaccuracy;
			}
			
			muzzlevelocity = muzzlevelocity.normalized * projMuzzleVelocity;

			// Needs to change to get prefab from AttackSpell object
			projectile = Instantiate(projPrefab, transform.position, transform.rotation) as GameObject;
			projectile.GetComponent<projectileScript>().muzzleVelocity = muzzlevelocity;
			fireTimer = Time.time + RateOfFire;
		}
		else
			return;
	}
}