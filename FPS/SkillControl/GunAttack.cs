using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunAttack : SkillBase {
    public int teleportDistance;
    private void Start()
    {
        anim = GetComponentInChildren<AnimatorPlay>();
        base.Init();
    }
    public override void AttackSkill_0(GameObject go)
    {
        if (anim.currentAnimName==AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.gunAttack_0);
            SecondaryWeapansAttack0();
        }
    }

    public override void AttackSkill_1(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.gunAttack_1);
            SecondaryWeapansAttack1();
        }
    }

    public override void AttackSkill_2(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.gunAttack_2);
            SecondaryWeapansAttack2();
        }
    }
    public override void AttackSkill_3(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.gunAttack_3);
            SecondaryWeapansAttack3();
        }
    }


    /// <summary>
    /// 副武器攻击方式
    /// </summary>
    public void SecondaryWeapansAttack0()
    {
        StartCoroutine(ShotBullet(0.6f));
    }

    public IEnumerator ShotBullet(float a)
    {
        yield return new WaitForSeconds(a);
        Vector3 destination = transform.position + transform.forward * 1.6f + Vector3.up;
        GameObject bullet = pool.CreateObject("BulletPool_0", destination, transform.rotation);
        bullet.transform.DOMove(destination + bullet.transform.forward * 30, 1.2f);
        GameObject shot = pool.CreateObject("ShotPool_0", transform.position + Vector3.up + transform.forward, transform.rotation * Quaternion.Euler(180, 0, 0));
        pool.MyDestory(bullet, 1.2f);
        pool.MyDestory(shot, 0.4f);
    }

    /// <summary>
    /// 瞬步
    /// </summary>
    public void SecondaryWeapansAttack1()
    {
        GameObject effect_1 = pool.CreateObject("StepPool", transform.position, transform.rotation * Quaternion.Euler(180, 0, 0));
        effect_1.transform.position -= effect_1.transform.forward * 8;
        pool.MyDestory(effect_1, 0.6f);
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(teleportDirection.position.x + 1.4f, 0, teleportDirection.position.y + 0.6f) * teleportDistance, 0.2f);
        //transform.position = transform.position + new Vector3(teleportDirection.position.x + 1.4f, 0, teleportDirection.position.y + 0.6f) * teleportDistance;
        //transform.position = transform.position + Vector3.up * teleportDistance;
        transform.DOMove(transform.position + transform.forward * teleportDistance, 0.2f);
        //tweenPosition.Play();
        GameObject effect_0 = pool.CreateObject("ShieldPool", transform.position+Vector3.up*0.8f, transform.rotation);
        effect_0.transform.parent = transform;
        pool.MyDestory(effect_0, 5);
    }

    /// <summary>
    /// gun——轮回弹
    /// </summary>
    /// <returns></returns>
    public void SecondaryWeapansAttack2()
    {
        Vector3 destination = transform.position + transform.forward * 1.2f + Vector3.up * 2;
        GameObject bullet = pool.CreateObject("BulletPool_1", destination, transform.rotation);
        ChildBehaviour(0, 0, bullet.transform, transform);
        ChildBehaviour(1, 120, bullet.transform, transform);
        ChildBehaviour(2, 240, bullet.transform, transform);
        bullet.transform.DOMove(transform.position + transform.forward * 30, 3);
        pool.MyDestory(bullet, 3);
    }
    public void ChildBehaviour(int index, int angle, Transform tran, Transform target)
    {
        tran.GetChild(index).position = target.position + target.forward * 1.2f + Vector3.up * 2;
        tran.GetChild(index).rotation = target.rotation * Quaternion.Euler(0, angle, 0);
        tran.GetChild(index).gameObject.SetActive(true);
    }



    /// <summary>
    /// 枪临天下
    /// </summary>
    public void SecondaryWeapansAttack3()
    {
        CameraView(11, 10, 30);
        StartCoroutine(CamerRecovery(3.8f));
        Vector3 destination = transform.position + transform.forward * 10;
        Collider[] colliders = Physics.OverlapSphere(destination, 5);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                colliders[i].transform.DOMove(destination, 0.4f);
                colliders[i].GetComponent<EnemyState>().OnDamage(GetComponent<PlayerState>().attack);
            }
        }
        GameObject shine = pool.CreateObject("ShinePool", transform.position, transform.rotation);
        GameObject gun = pool.CreateObject("GunArrayPool", transform.position, transform.rotation);
        for (int i = 0; i < gun.transform.childCount; i++)
        {
            Transform target = shine.transform.GetChild(i);
            target.forward = (target.parent.GetChild(shine.transform.childCount - 1).position - target.position).normalized;
            gun.transform.GetChild(i).DOMove(target.position + target.forward, 0.4f);
            gun.transform.GetChild(i).rotation = shine.transform.GetChild(i).rotation;
            if (i % 3 == 0)
            {
                StartCoroutine(ShotDely(target, 0.6f));
            }
            else if (i % 3 == 1)
            {
                StartCoroutine(ShotDely(target, 1.2f));
            }
            else
            {
                StartCoroutine(ShotDely(target, 1.8f));
            }
        }
        pool.MyDestory(shine, 2.8f);
        pool.MyDestory(gun, 2);
    }

    /// <summary>
    /// 大招射击效果
    /// </summary>
    /// <param name="target"></param>
    /// <param name="delyTime"></param>
    /// <returns></returns>
    public IEnumerator ShotDely(Transform target, float delyTime)
    {
        yield return new WaitForSeconds(delyTime);
        GameObject bullet = pool.CreateObject("BulletPool_0", target.transform.position, target.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.Impulse);
        pool.MyDestory(bullet, 1.6f);
    }

    /// <summary>
    /// 相机恢复锁定时间
    /// </summary>
    /// <param name="delyTime"></param>
    /// <returns></returns>
    public IEnumerator CamerRecovery(float delyTime)
    {
        yield return new WaitForSeconds(delyTime);
        Camera.main.GetComponent<ThirdPersonCamera>().enabled = true;
    }

}
