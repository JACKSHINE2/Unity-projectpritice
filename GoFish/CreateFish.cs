using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFish : MonoBehaviour {
    public GameObject[] sprite;
    private float  timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            int number = Random.Range(0, 2);
            float a = Random.Range(-1.6f,4.4f);
            int b = Random.Range(0, 1) * 2 - 1;
            Vector3 startPosition = new Vector3(b * 10, a, 0);        
            GameObject fish = Instantiate(sprite[number],startPosition,Quaternion.Euler(0,180+180*b,0));
            timer = 0;
            
        }
	}
}
