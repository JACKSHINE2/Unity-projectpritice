using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {
    //quote the delegate event
    public  GameControl gameControl;
    // Use this for initialization
    void Start () {
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name!="Plane")
        {               
            gameControl.spaceCheck += collision.gameObject.GetComponent<InputFunc>().ChangColor;
        }
    }
   
    // Update is called once per frame
    void Update () {
        
    }

   
        
    
}
