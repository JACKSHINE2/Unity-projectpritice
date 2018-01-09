using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Transform target;
    Vector3 dir;
    Camera mCamera;
    public float smooth;                // how smooth the camera movement is

    // Use this for initialization
    void Start () {
        mCamera = GetComponent<Camera>();
        target = GameObject.FindWithTag("Player").transform;

        dir = transform.position-target.position;

    }

    // Update is called once per frame
    void Update () {
	}

    void LateUpdate()  //跟随
    {
        mCamera.transform.position= target.position + dir;
    }
}
