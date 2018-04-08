using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float sensitivity;
    public float minAngle;
    public float maxAngle;

    // Use this for initialization
    void Start () {
		
	}
	
    
	// Update is called once per frame
	void Update () {
        //按住鼠标右键再旋转
        if (Input.GetMouseButton(0)) {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            float rotationY= transform.eulerAngles.y + x;
            float rotationX= transform.eulerAngles.x + y;
            
            transform = new Vector3(-rotationX ,rotationY,0);


        }
    }
}
