using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {
    public float speedForward;
    public float speedRight;
    public GameObject enemyBulletPrefab;
    private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -3.6f || transform.position.x > 3.6f)
        {
            speedRight = -speedRight;
        }
        transform.position += Vector3.back * speedForward*Time.deltaTime + Vector3.right * speedRight*Time.deltaTime;
        //发射子弹
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Instantiate(enemyBulletPrefab,transform.position,Quaternion.identity);
            timer = 0;
        }

	}
}
