using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCoins : MonoBehaviour {
    private GameObject CoinPrefab;
    private Random example;
    private float timer;
    // Use this for initialization
    void Start () {
        CoinPrefab = Resources.Load<GameObject>("Coin");
        example = new Random();
    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            float x = Random.Range(-9.5f, 9.5f);
            GameObject obj = Instantiate(CoinPrefab, new Vector3(x, 9.5f, -0.5f), Quaternion.identity);
            timer = 0;
            Destroy(obj, 6);
        }
    }
}
