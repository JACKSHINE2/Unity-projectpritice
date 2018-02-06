using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateEnemy : MonoBehaviour {
    float timer;
    public GameObject enemies;
    NavMeshRun navMesh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer>Random.Range(1.0f,2.0f))
        {
            GameObject enemy= Instantiate(enemies, transform.position, Quaternion.identity);
            timer = 0;
        }
	}
}
