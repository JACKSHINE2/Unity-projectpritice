using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerCollider : MonoBehaviour {
    public float smooth;
    
    // Use this for initialization

    void Start () {

    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Coin") )
        {
            //other.transform.position = Vector3.Lerp(other.transform.position, transform.position, smooth * Time.deltaTime);
            other.transform.position= Vector3.MoveTowards(other.transform.position,transform.position,0.5f);
            
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
