using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public float height;
    public float back;
    public float view;
    private Transform player_1;
    private Transform player_2;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time<0.05f)
        {
            player_1 = GameObject.FindWithTag("Player1").transform;
            player_2 = GameObject.FindWithTag("Player2").transform;
        }
	}
    private void LateUpdate()
    {
        if (player_1 && player_2)
        {
            Camera.main.transform.LookAt((player_1.position + player_2.position) / 2.0f);


            float distance = (player_1.position - player_2.position).magnitude;
            if (distance > 30)
            {
                Camera.main.transform.position = (player_1.position + player_2.position) / 2.0f + transform.up * height - transform.forward * back- transform.forward * view*(distance-30);
            }
        }



           
        
    }
}
 