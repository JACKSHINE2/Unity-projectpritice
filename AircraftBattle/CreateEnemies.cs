using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour {
    public GameObject[] prefabs;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Create", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Create() {
        //随机获得预制体
        int index = Random.Range(0,prefabs.Length);
        GameObject prefab = prefabs[index];
        //随机出现位置
        float a = Random.Range(-3.5f, 3.5f);
        GameObject enemy = Instantiate(prefabs[index], new Vector3(a, 0.5f, 8), Quaternion.identity);
    }
}
