using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleSpeed : MonoBehaviour {
    public float anglespeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * anglespeed * Time.deltaTime);

	}
}
