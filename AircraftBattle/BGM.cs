using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
    private Vector3 startPosition;
    public float scrollSpeed;
    public float sizeZ;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, sizeZ);
        transform.position = startPosition + Vector3.back * newPosition;
	}
}
