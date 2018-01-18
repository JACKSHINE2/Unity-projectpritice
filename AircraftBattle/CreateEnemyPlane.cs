using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyPlane : MonoBehaviour {
    float timer1,timer2;
    public GameObject enemyPlanePrefab;
    public GameObject stonePrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        
        if (timer1 >= 2)
        {
            CreateEnemy(enemyPlanePrefab);
            timer1 = 0;
        }
        if (timer2>=4)
        {
            CreateEnemy(stonePrefab);
            timer2 = 0;
        }
	}
    

    void CreateEnemy(GameObject obj)
    {
        float a = Random.Range(-3.5f, 3.5f);
        GameObject enemy = Instantiate(obj, new Vector3(a, 0.5f, 8), Quaternion.identity);
    }

}
