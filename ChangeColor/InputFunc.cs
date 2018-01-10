using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFunc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
    public  void ChangColor(Color newColor)
    {
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
