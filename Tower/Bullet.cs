using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Transform enemy;
	// Use this for initialization
	void Start () {
        enemy = Fire.enemy;
        Destroy(gameObject, 6);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position,);
        if (enemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.position, 0.2f);
        }
        else
        {
            Destroy(gameObject);  
        }
    }
}
