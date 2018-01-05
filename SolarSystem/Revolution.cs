using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Revolution : MonoBehaviour {
    //[HideInInspector]   //只会影响一句
    public Transform traget;
    //public GameObject star;
    public float anglespeed;
    Vector3 lastposition;
    // Use this for initialization
    void Start () {
        lastposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.RotateAround(traget.position,traget.up,anglespeed*Time.deltaTime);
        Debug.DrawLine(transform.position, lastposition, Color.yellow);
        lastposition = transform.position;

    }
}
