using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatess : MonoBehaviour {
	private float z;
	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		z = Camera.main.WorldToScreenPoint (transform.position).z;
		Vector3 pos1 = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,z);
		Vector3 pos2 = Camera.main.ScreenToWorldPoint (pos1);
		float angle = Vector3.Angle (pos2-transform.position,Vector3.up);
		print (angle);
		if (pos2.x - transform.position.x < 0) {
			transform.rotation = Quaternion.Euler (0, 0, angle);

		} else {
			transform.rotation = Quaternion.Euler (0, 0, -angle);
		}
	}
}
