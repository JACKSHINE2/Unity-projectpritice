using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    public float anglespeed;
    private Rigidbody mRigidbody;
    private void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate () {
        mRigidbody.MoveRotation(mRigidbody.rotation*Quaternion.Euler(anglespeed,0,0));
	}
}
