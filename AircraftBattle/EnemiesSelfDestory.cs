using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSelfDestory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -8.5f || transform.position.z >8.5f)
        {
            Destroy(gameObject);

        }
    }
}
