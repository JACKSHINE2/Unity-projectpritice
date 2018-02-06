using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    GameObject[] desks;
    Ray ray;
    Vector3 offest;


    public GameObject arrow;
	// Use this for initialization
	void Start () {
        arrow.SetActive(false);

        offest = 2.8f * Vector3.up;
        desks = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.gameObject.tag=="Player")
                {
                    print("22222");
                    arrow.SetActive(true);
                    arrow.transform.position = hit.collider.transform.position + offest;
                }
                else
                {
                    print("111111");
                    arrow.SetActive(false);
                }

            }
        }
		
	}
    
}
