using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    public float speedForward;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.back * speedForward*Time.deltaTime;
        if (transform.position.z < -8.5f)
        {
            Destroy(gameObject);

        }
    }
}
