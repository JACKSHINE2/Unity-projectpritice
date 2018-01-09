using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Cursor is invisible
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //press the "ESC"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
	}
}
