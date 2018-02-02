using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    RectTransform dir;
    public float speed;
	// Use this for initialization
	void Start () {
        dir = GameObject.Find("content").GetComponent<RectTransform>();
	}
    private void FixedUpdate()
    {
        transform.position += new Vector3(dir.anchoredPosition.x, 0, dir.anchoredPosition.y) * Time.fixedDeltaTime * speed;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
