using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHP : MonoBehaviour {
    TankController tank;
	// Use this for initialization
	void Start () {
        tank = GetComponentInParent<TankController>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Image>().fillAmount = tank.HP / 3.0f;
	}
}
