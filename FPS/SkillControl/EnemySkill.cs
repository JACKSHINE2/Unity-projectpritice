using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public  enum SkillArray
{
    a,
    b,
    c,
}
public class EnemySkill : SkillBase
{
    public SkillArray skillArray;
    public Transform player;
    EnemyState enemyState;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<AnimatorPlay>();
        base.Init();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = GetComponent<EnemyState>();
    }

    // Update is called once per frame

    public void SeletSkill()
    {
        int a = UnityEngine.Random.Range(0, 2);
        switch (skillArray)
        {
            case SkillArray.a:
                {
                    if (a == 0) AttackSkill_0(gameObject);
                    else AttackSkill_1(gameObject);
                    break;
                }
            case SkillArray.b:
                {
                    if (a == 0) AttackSkill_1(gameObject);
                    else AttackSkill_2(gameObject);
                    break;
                }
            case SkillArray.c:
                {
                    if (a == 0) AttackSkill_2(gameObject);
                    else AttackSkill_0(gameObject);
                    break;
                }
            default:
                break;
        }
    }

    /// <summary>
    /// 飞弹
    /// </summary>
    public override void AttackSkill_0(GameObject go)
    {
        anim.PlayAnim(AnimationName.swordAttack_0);
        StartCoroutine(SkillDelay_0("EnemyPool_0", 0.6f, 0.3f));
    }
    public IEnumerator SkillDelay_0(string poolName, float delayTime_0, float delayTime_1)
    {
        yield return new WaitForSeconds(delayTime_0);
        GameObject bullet_0 = pool.CreateObject(poolName, transform.position + Vector3.up * 2, transform.rotation);
        bullet_0.transform.DOMove(transform.position + transform.forward * 12, 2);
        yield return new WaitForSeconds(delayTime_1);
        GameObject bullet_1 = pool.CreateObject(poolName, transform.position + Vector3.up * 2, transform.rotation);
        bullet_1.transform.DOMove(transform.position + transform.forward * 12, 2);
        yield return new WaitForSeconds(delayTime_0 + 2 - delayTime_1);
        pool.MyDestory(bullet_0);
        yield return new WaitForSeconds(delayTime_1);
        pool.MyDestory(bullet_1);
    }

    /// <summary>
    /// 重锤，圆形攻击范围
    /// </summary>
    public override void AttackSkill_1(GameObject go)
    {
        anim.PlayAnim(AnimationName.swordAttack_1);
        StartCoroutine(SkillDelay1("EnemyPool_1", 1.1f));
    }

    public IEnumerator SkillDelay1(string poolName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject bullet = pool.CreateObject(poolName, transform.position + Vector3.up*0.8f, transform.rotation);
        if (Vector3.Distance(player.position, transform.position) < 4)
        {
            player.GetComponent<PlayerState>().OnDamage(enemyState.attack);
        }
        yield return new WaitForSeconds(1);
        pool.MyDestory(bullet);
    }

    /// <summary>
    /// 穿刺，扇形攻击范围
    /// </summary>
    public override void AttackSkill_2(GameObject go)
    {
        anim.PlayAnim(AnimationName.swordAttack_2);
        StartCoroutine(SkillDelay2("EnemyPool_2", 1));
    }

    private IEnumerator SkillDelay2(string poolName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject bullet = pool.CreateObject(poolName, transform.position+Vector3.up*0.4f, transform.rotation);
        if (Vector3.Distance(transform.position, player.position) < 3 && Vector3.Angle(transform.forward, player.position) < 90)
        {
            player.GetComponent<PlayerState>().OnDamage(enemyState.attack);
        }
        yield return new WaitForSeconds(2);
        pool.MyDestory(bullet);
    }
}

