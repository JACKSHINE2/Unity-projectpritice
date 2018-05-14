using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartSceneShowPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.instance.Init();
        UIManager.instance.IsActive("BackGorundPanel",true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
