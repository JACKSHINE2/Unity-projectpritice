using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SkillControl : MonoBehaviour {

    public AnimatorPlay anim;
    public int teleportDistance;
    
    /// <summary>
    /// 大招不可被打断
    /// </summary>

    public BulletPool pool;
    private bool dazzleInsist;

    public void Start()
    {
        //测试 
        anim = GetComponentInChildren<AnimatorPlay>();
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
        dazzleInsist = anim.currentAnimName == AnimationName.swordAttack_3|| anim.currentAnimName == AnimationName.gunAttack_3;
    }
    // Use this for initialization


    /// <summary>
    /// 主武器攻击方式
    /// </summary>

    /// <summary>
    /// sword——普攻
    /// </summary>   
    public void PrimaryWeaponsAttack0()
    {
        if (dazzleInsist) return;

        if (anim.currentAnimName==AnimationName.swordAttack_0) return;
        anim.PlayAnim(AnimationName.swordAttack_0);
        StartCoroutine(SlashDely());
    }
    public IEnumerator SlashDely()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject slash = pool.CreateObject("SlashPool", transform.position + new Vector3(-0.5f, 1, 1.5f), transform.rotation);
        pool.MyDestory(slash, 0.4f);
    }


    /// <summary>
    /// sword——圆灭斩
    /// </summary>
    public void PrimaryWeaponsAttack1()
    {
        if (dazzleInsist) return;
        if (anim.currentAnimName == AnimationName.swordAttack_1) return;
        anim.PlayAnim(AnimationName.swordAttack_1);
        StartCoroutine(RoundDely());
    }
    public IEnumerator RoundDely()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject slash = pool.CreateObject("RoundPool", transform.position + transform.forward * 10+transform.up, transform.rotation);
        pool.MyDestory(slash, 0.6f);
    }


    /// <summary>
    /// sword——月牙天冲
    /// </summary>
    /// <returns></returns>
    public void PrimaryWeaponsAttack2()
    {
        if (dazzleInsist) return;

        if (anim.currentAnimName == AnimationName.swordAttack_2) return;
        anim.PlayAnim(AnimationName.swordAttack_2);
        StartCoroutine(CrescentDely());
    }
    public IEnumerator CrescentDely()
    {
        yield return new WaitForSeconds(0.44f);
        GameObject crescent_0 = pool.CreateObject("CrescentPool", transform.position +Vector3.up * 0.2f, transform.rotation);
        crescent_0.GetComponent<Rigidbody>().velocity=transform.forward*20;
        //crescent_0.transform.DOMove(transform.)
        pool.MyDestory(crescent_0, 1.2f);

        yield return new WaitForSeconds(0.4f);
        GameObject crescent_1 = pool.CreateObject("CrescentPool", transform.position + Vector3.up+transform.right*0.5f, transform.rotation);
        crescent_1.transform.rotation *= Quaternion.Euler(0, 0, 90);
        crescent_1.GetComponent<Rigidbody>().velocity = transform.forward * 20;
        pool.MyDestory(crescent_1, 1.4f);

        yield return new WaitForSeconds(0.4f);
        GameObject crescent_2 = pool.CreateObject("CrescentPool", transform.position + Vector3.up*2.4f+transform.right*1.2f, transform.rotation);
        crescent_2.transform.rotation *= Quaternion.Euler(0, 0, 90);
        crescent_2.GetComponent<Rigidbody>().velocity = transform.forward * 20;
        crescent_2.transform.localScale = new Vector3(3.6f, 3.6f, 3.6f);
        pool.MyDestory(crescent_2, 1.8f);
    }

    /// <summary>
    /// sword——八剑纵横
    /// </summary>
    /// <returns></returns>  
    public void PrimaryWeaponsAttack3()
    {
        if (dazzleInsist) return;
        transform.GetChild(1).gameObject.SetActive(true);
        anim.PlayAnim(AnimationName.swordAttack_3);
        StartCoroutine(ArrayDely());
    }
    public IEnumerator ArrayDely()
    {
        float attackRange = 5.2f;
        float swordCount = 8.0f;
        Transform[] sword = new Transform[(int)swordCount];
        GameObject ArraySword = pool.CreateObject("SwordArrayPool", transform.position + transform.forward*4+Vector3.up, transform.rotation);
        CameraView(12,4,40);
        for (int i = 0; i < sword.Length; i++)
        {
            sword[i] = ArraySword.transform.GetChild(0).GetChild(i);
            sword[i].DOMove(sword[0].parent.position + new Vector3(attackRange * Mathf.Cos(i*2*Mathf.PI / swordCount), 3, attackRange * Mathf.Sin(i * 2*Mathf.PI  / swordCount)), 1);
        }
        Collider[] colliders = Physics.OverlapSphere(ArraySword.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                //静止怪物动画播放
                colliders[i].transform.DOMove(colliders[i].transform.position + Vector3.up, 0.4f);
            }
        }
        

        yield return new WaitForSeconds(1.4f);
        ArraySword.transform.DORotate(transform.eulerAngles+360*Vector3.up, 2);
        yield return new WaitForSeconds(1.4f);
        transform.DOLookAt(sword[6].position, 0.04f);
        transform.DOMove(sword[6].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[1].position, 0.04f);
        transform.DOMove(sword[1].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[4].position, 0.04f);
        transform.DOMove(sword[4].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[7].position, 0.04f);
        transform.DOMove(sword[7].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[2].position, 0.04f);
        transform.DOMove(sword[2].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[5].position, 0.04f);
        transform.DOMove(sword[5].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[0].position, 0.04f);
        transform.DOMove(sword[0].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[3].position, 0.04f);
        transform.DOMove(sword[3].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[6].position, 0.04f);
        transform.DOMove(sword[6].position, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLookAt(sword[2].position, 0.04f);
        Camera.main.GetComponent<ThirdPersonCamera>().enabled = true;
        transform.DOMove(sword[2].position-Vector3.up*3, 0.3f);
        yield return new WaitForSeconds(0.3f);
        anim.PlayAnim(AnimationName.swordAttackend_3);
        for (int i = 0; i < sword.Length; i++)
        {
            sword[i].localPosition = Vector3.zero;
        }
        transform.GetChild(1).gameObject.SetActive(false);
        pool.MyDestory(ArraySword);
    }


    /// <summary>
    /// 副武器攻击方式
    /// </summary>
    public void SecondaryWeapansAttack0()
    {
        if (dazzleInsist) return;
        anim.PlayAnim(AnimationName.gunAttack_0);
        Vector3 destination = transform.position +transform.forward*1.6f+ Vector3.up;
        GameObject bullet = pool.CreateObject("BulletPool_0", destination, transform.rotation);
        if (bullet == null) return;
        //bullet.transform.DOMove(destination + bullet.transform.forward * 15, 1.1f);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.Impulse);
        GameObject shot = pool.CreateObject("ShotPool_0", transform.position+Vector3.up+transform.forward, transform.rotation*Quaternion.Euler(180,0,0));
        pool.MyDestory(bullet, 2.6f);
        pool.MyDestory(shot, 0.4f);
    }

    /// <summary>
    /// 瞬步
    /// </summary>
    public void SecondaryWeapansAttack1()
    {
        if (dazzleInsist) return;
        anim.PlayAnim(AnimationName.gunAttack_1);
        GameObject effect_1 = pool.CreateObject("StepPool", transform.position, transform.rotation * Quaternion.Euler(180, 0, 0));
        effect_1.transform.position -= effect_1.transform.forward * 8;
        pool.MyDestory(effect_1, 0.6f);
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(teleportDirection.position.x + 1.4f, 0, teleportDirection.position.y + 0.6f) * teleportDistance, 0.2f);
        //transform.position = transform.position + new Vector3(teleportDirection.position.x + 1.4f, 0, teleportDirection.position.y + 0.6f) * teleportDistance;
        //transform.position = transform.position + Vector3.up * teleportDistance;
        transform.DOMove(transform.position + transform.forward * teleportDistance, 0.2f);
        //tweenPosition.Play();
        GameObject effect_0 = pool.CreateObject("ShieldPool", transform.position, transform.rotation);
        effect_0.transform.parent = transform;
        pool.MyDestory(effect_0, 5);
    }

    /// <summary>
    /// gun——轮回弹
    /// </summary>
    /// <returns></returns>
    public void SecondaryWeapansAttack2()
    {
        if (dazzleInsist) return;
        anim.PlayAnim(AnimationName.gunAttack_2);
        Vector3 destination = transform.position + transform.forward * 1.2f+ Vector3.up*2;
        GameObject bullet = pool.CreateObject("BulletPool_1", destination, transform.rotation);
        ChildBehaviour(0, 0, bullet.transform, transform);
        ChildBehaviour(1, 120, bullet.transform, transform);
        ChildBehaviour(2, 240, bullet.transform, transform);
        bullet.transform.DOMove(transform.position + transform.forward * 30, 3);
        pool.MyDestory(bullet, 3);
    }
    public void ChildBehaviour(int index,int angle, Transform tran,Transform target)
    {
        tran.GetChild(index).position = target.position+target.forward*1.2f+Vector3.up*2;
        tran.GetChild(index).rotation = target.rotation * Quaternion.Euler(0, angle, 0);
        tran.GetChild(index).gameObject.SetActive(true);
    }

  

    /// <summary>
    /// 枪临天下
    /// </summary>
    public void SecondaryWeapansAttack3()
    {
        if (dazzleInsist) return;
        CameraView(11,10,30);
        StartCoroutine(CamerRecovery(3.8f));
        anim.PlayAnim(AnimationName.gunAttack_3);
        Vector3 destination = transform.position + transform.forward * 10;
        Collider[] colliders = Physics.OverlapSphere(destination, 5);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag=="Enemy")
            {
                colliders[i].transform.DOMove(destination, 0.4f);
                colliders[i].GetComponent<EnemyState>().OnDamage(GetComponent<PlayerState>().attack);
            }
        }
        GameObject shine= pool.CreateObject("ShinePool", transform.position, transform.rotation);
        GameObject gun = pool.CreateObject("GunArrayPool", transform.position, transform.rotation);
        for (int i = 0; i < gun.transform.childCount; i++)
        {
            Transform target = shine.transform.GetChild(i);
            target.forward=(target.parent.GetChild(shine.transform.childCount - 1).position-target.position).normalized;
            gun.transform.GetChild(i).DOMove(target.position + target.forward, 0.4f);
            gun.transform.GetChild(i).rotation = shine.transform.GetChild(i).rotation;
            if (i%3==0)
            {
                StartCoroutine(ShotDely(target, 0.6f));
            }
            else if (i%3==1)
            {
                StartCoroutine(ShotDely(target, 1.2f));
            }
            else
            {
                StartCoroutine(ShotDely(target, 1.8f));
            }            
        }
        anim.PlayAnim(AnimationName.Motion);
        pool.MyDestory(shine, 2.8f);
        pool.MyDestory(gun, 2);
    }

    /// <summary>
    /// 大招射击效果
    /// </summary>
    /// <param name="target"></param>
    /// <param name="delyTime"></param>
    /// <returns></returns>
    public IEnumerator ShotDely(Transform target,float delyTime)
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

    /// <summary>
    /// 视角改变
    /// </summary>
    public void CameraView(int height,int away, float angle)
    {
        Camera.main.GetComponent<ThirdPersonCamera>().enabled = false;
        Camera.main.transform.DOMove(transform.position + Vector3.up * height - transform.forward * away, 1.4f);
        Camera.main.transform.DORotate(transform.eulerAngles + transform.right * angle, 0.4f);
    }











 














}
