using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : CharacterState {
    public WeaponAppear weapon;
    BulletPool pool;
    PlayerState player;
    // Use this for initialization

    // Use this for initialization
    void Start() {
        base.Start();
        ReadData("EnemyState");
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
    }

    /// <summary>
    /// Boss死后
    /// </summary>
    public override void Death()
    {
        base.Death();
        weapon.SelectWeaponAppear();
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            //普通射击
            if (other.name.Contains("BlueLaserProjectile"))
            {
                GameObject hitObj = pool.CreateObject("BulletHitPool_0", transform.position, Quaternion.identity);
                pool.MyDestory(hitObj, 0.3f);
                other.gameObject.SetActive(false);
            }
            //特殊攻击
            else if (other.name.Contains("BlueRingProjectile"))
            {
                GameObject hitObj = pool.CreateObject("BulletHitPool_1", transform.position, Quaternion.identity);
                pool.MyDestory(hitObj, 0.3f);
                other.gameObject.SetActive(false);
            }
            else if (other.name.Contains("BaseStrikeEffect"))
            {
                GameObject hitObj = pool.CreateObject("SwordHitPool_1", transform.position, Quaternion.identity);
                pool.MyDestory(hitObj, 0.3f);
            }
            else if (other.name.Contains("RedLaserBoltImpact"))
            {
                GameObject hitObj = pool.CreateObject("SwordHitPool_0", transform.position, Quaternion.identity);
                pool.MyDestory(hitObj, 0.3f);
            }
            else if (other.name.Contains("Slash04"))
            {
                GameObject hitObj = pool.CreateObject("RoundHitPool", transform.position, Quaternion.identity);
                pool.MyDestory(hitObj, 0.3f);
            }
            //敌人受伤
            OnDamage(player.attack);
        }
    }  

    // Update is called once per frame
    void Update () {
		
	}
}
