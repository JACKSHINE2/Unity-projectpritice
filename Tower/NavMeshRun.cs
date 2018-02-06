using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshRun : MonoBehaviour {
    NavMeshAgent agent;
    Transform destination;
	// Use this for initialization
	void Start () {
        destination = GameObject.FindWithTag("Finish").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(destination.position, transform.position)<0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
