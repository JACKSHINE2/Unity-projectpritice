using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDistance : MonoBehaviour {
    TankController tankController;
    public GameObject aim;
    Vector3 location;
	// Use this for initialization
	void Start () {
        location = aim.transform.localPosition;
        tankController = GetComponent<TankController>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void LateUpdate()
    {
        if (tankController.power > 0.4f)
        {
            aim.SetActive(true);

            aim.transform.localPosition = location + Vector3.forward * 3 * (tankController.power - 0.4f) / 1.6f  *3.6f;
        }
        else if (tankController.power < 0.4f)
        {
            aim.transform.localPosition = location;
            aim.SetActive(false);
        }

    }
}
