using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position,transform.position+Vector3.forward,Time.deltaTime*0.5f);
        transform.Translate(Vector3.right*0.1f);
	}
}
