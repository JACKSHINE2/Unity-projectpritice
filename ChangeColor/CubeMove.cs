using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
    public float speed;
    private Rigidbody mRigidbody;
	// Use this for initialization
	void Start () {
        mRigidbody = gameObject.GetComponent<Rigidbody>();
	}
    // Update is called once per frame
    void FixedUpdate () {
        float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Vertical");
        //transform.gameObject.GetComponent<Rigidbody>().position += new Vector3(a*speed *Time.deltaTime ,0,b*speed*Time.deltaTime);
        //mRigidbody.MovePosition(mRigidbody.position + new Vector3(a * speed * Time.deltaTime, 0, b * speed * Time.deltaTime));
        mRigidbody.AddForce(new Vector3(a, 0, b) * speed * Time.deltaTime, ForceMode.Impulse);
        //mRigidbody.MoveRotation()


    }
}
