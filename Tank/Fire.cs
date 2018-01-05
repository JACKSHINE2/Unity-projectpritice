using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    float timer;
    public  GameObject prefab;
    Transform start;
	// Use this for initialization
	void Start () {
        start = GameObject.Find("Start").transform;
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        else if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                shoot();
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(prefab, start.position, start.rotation * Quaternion.Euler(80, 0, 0));
        Destroy(bullet, 5);
    }
}
