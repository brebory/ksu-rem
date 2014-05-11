using UnityEngine;
using System.Collections;

public class weaponScript : MonoBehaviour
{
	// public
	public GameObject Originator = null;
	public float projMuzzleVelocity;
	public GameObject spellPrefab1;
	public GameObject spellPrefab2;
	public GameObject spellPrefab3;
	public GameObject spellPrefab4;
	private GameObject spell;
	public float RateOfFire;
	public float Inaccuracy;
	//private Vector3 def = new Vector3(0, 0, 180);

	// private
	private float fireTimer;

	// Use this for initialization
	void Start ()
	{
		fireTimer = Time.time + RateOfFire;
		spell = spellPrefab1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("q")) {
			spell = spellPrefab1;
		}
		if (Input.GetKey ("w")) {
			spell = spellPrefab2;
		}
		if (Input.GetKey ("e")) {
			spell = spellPrefab3;
		}
		if (Input.GetKey ("r")) {
			spell = spellPrefab4;
		}


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
				
				//Set the originator for collisions
				Debug.Log("Originator = " + Originator);
				if(spell.GetComponent<Projectile_Collision>() != null){
					spell.GetComponent<Projectile_Collision>().Originator = Originator;
					Debug.Log("New Originator = " + Originator);
				}
				else if(spell.transform.FindChild("Sphere").GetComponent<Projectile_Collision>() != null){
					spell.transform.FindChild("Sphere").GetComponent<Projectile_Collision>().Originator = Originator;
					Debug.Log("New Originator = " + Originator);
				}
				
				projectile = Instantiate(spell, transform.position, transform.rotation) as GameObject;
				projectile.GetComponent<projectileScript>().muzzleVelocity = muzzlevelocity;
				fireTimer = Time.time + RateOfFire;
			}
			else
				return;
		}
	}
	
	
	/// <summary>
	/// Fires the given spell
	/// </summary>
	/// <param name="spell">The type of spell to fire</param>
	///
	/// <todo>
	/// Figure out why spell prefabs are being cloned, and why one stays at the origin
	/// </todo>



	public void FireWeapon()
	{
		// Dummy animation
		if (Time.time > fireTimer)
		{
			GameObject projectile;
			// Create velocity vector to spell position
			Vector3 muzzlevelocity = transform.position;
			
			if (Inaccuracy != 0)
			{
				Vector2 rand = Random.insideUnitCircle;
				muzzlevelocity += new Vector3(rand.x, rand.y, 0) * Inaccuracy;
			}
			
			muzzlevelocity = muzzlevelocity.normalized * projMuzzleVelocity;
			
			// TODO: Change to get prefab from IAttackSpell object.
			projectile = Instantiate(spell, transform.position, transform.rotation) as GameObject;
			projectile.GetComponent<projectileScript>().muzzleVelocity = muzzlevelocity;
			fireTimer = Time.time + RateOfFire;
		}
		else
			return;
	}
}
