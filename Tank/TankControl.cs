using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour {
    public float speed;
    public float angleSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(transform.forward*ver*speed*Time.deltaTime,Space.World);
        float a = ver >= 0 ? 1 : -1;
        transform.rotation *= Quaternion.Euler(0, a*hor*angleSpeed * Time.deltaTime, 0);

        //transform.Translate(new Vector3(1 * hor * speed * Time.deltaTime, 0, 1 * ver * speed * Time.deltaTime));

    }
}
