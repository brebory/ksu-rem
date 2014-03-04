using UnityEngine;
using System.Collections;

public class TestVisionBehavior : EnemyVisionBehavior {

	public double visionRadius = 10.0f;
	public double angleOfView = 120.0f;
	private GameObject player;
	private Color defaultColor;
	// Use this for initialization
	void Start () {
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
		defaultColor = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckVisible(player)) {
			gameObject.renderer.material.color = Color.red;
		} else {
			gameObject.renderer.material.color = defaultColor;
		}
		Debug.Log(GetVisibleObjects());
		Debug.Log(GetVisibleObjects().Count);
	}

	public override double GetVisionRadius() {
		return visionRadius;
	}

	public override double GetAngleOfView() {
		return angleOfView;
	}
}
