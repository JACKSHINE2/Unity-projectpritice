using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public  delegate void SpaceCheck(Color newColor);
    public  event SpaceCheck spaceCheck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            spaceCheck(Color.red);
        }
	}
}
