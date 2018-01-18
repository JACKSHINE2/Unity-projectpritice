using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary
{
    [SerializeField]
    public float xMin, xMax, zMin, zMax;
}
public class PlayerControler : MonoBehaviour {
    public Boundary boundary;
    public float speed;
    private  Rigidbody mrigidbody;
    public GameObject shotPrefab;
    private Transform shotTransform;
    
	// Use this for initialization
	void Start () {
        mrigidbody = GetComponent< Rigidbody>();        
        shotTransform = transform.Find("Shot Spawn");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet= Instantiate(shotPrefab,shotTransform.position,Quaternion.identity);            
        }
	
	}
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        mrigidbody.velocity = new Vector3(hor, 0, ver)*speed;
        float x = Mathf.Clamp(mrigidbody.position.x, boundary.xMin, boundary.xMax);
        float z = Mathf.Clamp(mrigidbody.position.z, boundary.zMin, boundary.zMax);
        mrigidbody.position = new Vector3(x, mrigidbody.position.y, z);

    }
}
