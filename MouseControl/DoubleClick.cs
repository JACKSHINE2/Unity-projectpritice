using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour {
    public float timer;
    float clickCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount==0)
            {
                timer += Time.deltaTime;
            }
            clickCount++;
            if (clickCount ==2 && (Time.time - timer) <= 0.3f)
            {
                print("Double-Click");
                clickCount = 0;
            }
            if (Time.time -timer>0.3f)
            {
                clickCount = 0;
            }
        }
	}
}
