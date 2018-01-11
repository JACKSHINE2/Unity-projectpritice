using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public delegate void DIsapearBall();
    public event DIsapearBall disapearEvent;
    private Rigidbody mRigidbody;

    // Use this for initialization
    void Start () {
        mRigidbody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               mRigidbody.velocity = hit.point - mRigidbody.position;
                }           
        }
        if (transform.position.magnitude>20)
        {
            disapearEvent();
            Destroy(gameObject);
        }        
    }
}
