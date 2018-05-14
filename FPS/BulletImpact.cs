using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BulletImpact : MonoBehaviour {
    public BulletPool pool;
    private void Start()
    {
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
        
    }
    void Update () {
        if (transform.name.Contains("BlueRingProjectile"))
        {
            transform.RotateAround(transform.parent.position, Vector3.up, 3);
            transform.position -= transform.forward * 0.2f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Building"&&transform.name.Contains("BlueLaserProjectile"))
        {
            GameObject hitObj = pool.CreateObject("BulletHitPool_0", transform.position, Quaternion.identity);
            pool.MyDestory(hitObj, 0.3f);
            gameObject.SetActive(false);
        }

        if (other.tag=="Player"&& transform.name.Contains("ShockwaveProjectile"))
        {
            float attackValue = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyState>().attack;
            other.GetComponent<PlayerState>().OnDamage(attackValue);
        }
    }



}



