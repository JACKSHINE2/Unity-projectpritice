using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    Vector3 StartPosition;
    Vector3 offest;
    Rigidbody2D  mRigidbody;
    float z;
    
    private GameObject obj;
	// Use this for initialization
	void Start () {
        mRigidbody = GetComponent<Rigidbody2D>();
        obj = GameObject.Find("Box");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        StartPosition = transform.position;
        obj.SetActive(false);
        z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 pos1 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        Vector3 pos2 = Camera.main.ScreenToWorldPoint(pos1);
        offest = transform.position - pos2;
    }

    private void OnMouseDrag()
    {
        z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mousePosition2D = new Vector3(Input.mousePosition.x,Input.mousePosition.y,z);
        Vector3 worldPosition2D = Camera.main.ScreenToWorldPoint(mousePosition2D);
        transform.position = worldPosition2D+offest;
    }
    private void OnMouseUp()
    {
        Vector3 dir = StartPosition - transform.position;
        mRigidbody.AddForce(new Vector2(dir.x, dir.y)*10,ForceMode2D.Impulse);
    }
}
