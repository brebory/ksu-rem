using UnityEngine;
using System.Collections;

public class TestVisionBehavior : EnemyVisionBehavior {

	private double visionRadius = 1.0f;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckVisible(player)) {
			this.gameObject.renderer.material.color = Color.red;
			Debug.Log("Enemy Spotted.");
		} else {
			this.gameObject.renderer.material.color = Color.gray;
			Debug.Log("Lost Contact.");
		}
	}

	private double getVisionRadius() {
		return visionRadius;
	}
}
