using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour {
    public float mSensitivity;
    public float maxDistance;
    public float minDistance;
    public float distance;
    public Transform target;
    public Vector3 offset; //与物体无角度变化

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position; //锁死与目标物体的向量位置
        distance = offset.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        distance += Input.GetAxis("Mouse ScrollWheel")*mSensitivity;
        //限制鼠标滚轮的距离
        float dis = Mathf.Clamp(distance,minDistance,maxDistance);
        transform.position = offset.normalized*dis+target.position;
        
	}
}
