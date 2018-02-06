using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTower : MonoBehaviour {
    public GameObject[] tower;

    float timer;
    float i=0.04f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right,0.4f);
        timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right * i, 0.01f);

        if (timer>1)
        {
            //transform.Translate(Vector3.right*i);
            timer = 0;
            i =-i;
        }
        Create(0);
        Create(1);
        Create(2);
        Create(3);







    }

    public void Create(int index)
    {
        if (Input.GetKeyDown(index.ToString()))
        {
            GameObject obj= Instantiate(tower[index], transform.position, Quaternion.identity);
            BoxCollider box= obj.AddComponent<BoxCollider>();
            box.isTrigger = true;

            gameObject.SetActive(false);
        }

    }

}
