using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatBall : MonoBehaviour {
    private GameObject ballPrefab;
    private Vector3 startPoint;
    float z;
	// Use this for initialization
	void Start () {
        ballPrefab = Resources.Load<GameObject>("Ball");
        startPoint = Camera.main.transform.position + Camera.main.transform.forward*4;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                BallMove(hit.point);
            }
            else
            {
                z = Camera.main.WorldToScreenPoint(new Vector3 (0,0,0)).z;
                Vector3 destination = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,z));
                BallMove(destination);
            }
        } 
	}
    void BallMove(Vector3 endPoint) {
        GameObject ball = Instantiate(ballPrefab, startPoint, Quaternion.identity);
        //ball.GetComponent<Rigidbody>().AddForce((endPoint - startPoint), ForceMode.Impulse);
        //ball.transform.Translate(endPoint - startPoint);
        ball.GetComponent<Rigidbody>().velocity = endPoint - startPoint;
        Destroy(ball, 6);
    }
}
