using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAward : MonoBehaviour {
    Transform player;
    BulletPool pool;
    bool isShow=true;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.position,transform.position)<1&&isShow)
        {
            player.GetComponentInChildren<WeaponBag>().WeaponUpgradet();
            pool.CreateObject("WeaponGetPool", player.position, player.rotation);
            isShow = false;
        }
	}
}
