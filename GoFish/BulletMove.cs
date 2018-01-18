using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    // Use this for initialization
    public GameObject exploration;
    private Rigidbody2D mRigidbody;
    void Start () {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.velocity = transform.up*20;
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fish")
        {
            Instantiate(exploration,other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
