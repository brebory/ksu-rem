using UnityEngine;
using System.Collections;

public class FiniteStateMachine : MonoBehaviour {

	private GameObject EnemyTarget;
	public float moveSpeed;

	public enum EnemyStates
	{
		sleeping = 0,
		following = 1,
		attacking = 2,
		beingHit = 3,
		dying = 4
	}

	//Enemy starts off sleeping
	public EnemyStates currentState;

	// Use this for initialization
	void Start () {
		EnemyTarget = GameObject.Find("SombreroMan");
	}
	
	// Update is called once per frame
	void Update () {
		//Run code based on which state is active
		switch(currentState)
		{
		case EnemyStates.sleeping:
			//Enemy is sleeping
			//Animation timing logic for a sleep animation goes here
			animation.Play("Idle");

			//Check if player has approached logic
			if(gameObject.GetComponent<EnemyTarget>())
			{
				currentState = 2;
			}
			//Logic for making enemy follow player and attack when in range
			//"currentState = EnemyStates.following;"
			//Attack rotation logic here
			break;

		case EnemyStates.following:
			//Enemy is following a target
			if(gameObject.GetComponent<EnemyVBehavior>().CheckLOS(EnemyTarget))
			{
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.GetComponent<path_finder>().pathTo(EnemyTarget), moveSpeed * Time.deltaTime);
				animation.Play("Walk");
			}
			else
			{
				//Path_finder must find last known location
				gameObject.GetComponent<path_finder>().last_seen_node();
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.GetComponent<path_finder>().pathTo(EnemyTarget), moveSpeed * Time.deltaTime);

			}

			break;

		case EnemyStates.attacking:
			//Enemy is attacking
			if(gameObject.getComponent<EnemyVisionBehavior>().in_range())
			{
				EnemyTarget.getComponent<Health>().decrementHealth(5);
				animation.play("Attack");
			}
			break;

		case EnemyStates.beingHit:
			//Enemy is being hit
			//Check if animation is complete
			//Check state of enemy target (dead or alive)
			//If alive, follow/attack it; If dead, go to sleep
			if(gameObject.getComponent<Health>().health == 0)
			{
				currentState = 4;
			}
			else
			{
				gameObject.getComponent<Health>().decrementHealth(5);
				currentState = 1;
			}
			break;

		case EnemyStates.dying:
			//Enemy is dying so wait for end of death animation
			//When animation is complete, destroy enemy GameObject
			animation.play("Death");
			WaitForSeconds(5);
			Destroy(gameObject);
			break;
		}
	}
}
