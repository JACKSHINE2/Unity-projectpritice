using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : MonoBehaviour {
    public float sensitivity = 2.0f;
    public float MinimumX=-90f;
    public float MaximumX=90f;
    public float smooth = 5.0f;
    private Transform mCameraTransform;
    private Quaternion parentTragetRot;
    private Quaternion cameraTargetRot;
    // Use this for initialization
    void Start () {
        //Camera.main.gameObject.GetComponent<CameraFollow>().enabled =false;
        parentTragetRot= transform.localRotation;
        cameraTargetRot = Camera.main.transform.localRotation;
	}

    
	
	// Update is called once per frame
        //get the angle of the 
	void Update () {
        //get the angle of the axis X and Y
        float yRot = Input.GetAxis("Mouse X")*sensitivity;
        float xRot = Input.GetAxis("Mouse Y") * sensitivity;
        parentTragetRot *= Quaternion.Euler(0,yRot,0);
        cameraTargetRot *= Quaternion.Euler(xRot, 0, 0);
        //constrant of axis Y
        cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);
        //rotate smoothly
        transform.localRotation = Quaternion.Slerp(transform.localRotation, parentTragetRot, Time.deltaTime*smooth);
        Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation,cameraTargetRot,Time.deltaTime *smooth);
	}
    //angle constrant
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
