using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMove : MonoBehaviour {
    Vector2 mPos1;
    public UISlider uiSlider;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount<=0)
        {
            return;
        }
        if (Input.touchCount==1)
        {
            if (Input.touches[0].phase==TouchPhase.Began)
            {
                mPos1 = Input.touches[0].position;
            }
            if (Input.touches[0].phase==TouchPhase.Moved)
            {
                transform.Rotate(transform.up, Input.touches[0].deltaPosition.x*5* uiSlider.value);
                transform.Rotate(transform.forward, Input.touches[0].deltaPosition.y*5*uiSlider.value);


            }
        }
	}
}
