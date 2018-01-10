using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFunc : MonoBehaviour {
    // Use this for initialization
    private int count;
	void Start () {
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coins")
        {
            ++count;
            print("抢到金币数："+count);
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
