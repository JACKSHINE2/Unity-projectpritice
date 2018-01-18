using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRot : MonoBehaviour {
    float z;

	// Use this for initialization
	void Start () {
        z = Camera.main.WorldToScreenPoint(transform.position).z;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, z));
        Vector3 dir = target - transform.position;
        float y = Mathf.Clamp(dir.y, 0, 20000);
        transform.up = new Vector3(dir.x, y, dir.z);
        
	}
}
