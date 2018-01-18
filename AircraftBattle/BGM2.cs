using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM2 : MonoBehaviour {
    private MeshRenderer MR;
	// Use this for initialization
	void Start () {
        MR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        MR.material.mainTextureOffset -= new Vector2(0, Time.deltaTime * 0.02f);
	}
}
