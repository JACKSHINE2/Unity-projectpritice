using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSphere : MonoBehaviour {
    public GameObject sphere;
    float z;
	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update () {
        
        if (Input.GetMouseButtonDown(0)) {
            z = Camera.main.WorldToScreenPoint(sphere.transform.position).z;
            Vector3 pos1 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
            Vector3 pos2 = Camera.main.ScreenToWorldPoint(pos1);
            GameObject obj = Instantiate(sphere, pos2, Quaternion.identity);
            Destroy(obj,3);
        }
     }
}
