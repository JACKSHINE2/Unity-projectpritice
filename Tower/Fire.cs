using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public  GameObject bullet;
    public  static Transform enemy;
    float coldTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] collider = Physics.OverlapSphere(transform.position,20);        
            for (int i = 0; i < collider.Length; i++)
            {
                if (collider[i].tag=="Enemy" && coldTime < Time.time - 1.8f)
                {
                    enemy = collider[i].transform;
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    coldTime = Time.time;
                }
            }
    }

    
}
