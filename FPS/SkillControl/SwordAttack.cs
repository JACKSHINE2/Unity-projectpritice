using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AI.FSM;


public class SwordAttack : SkillBase
{
    BaseFSM enemy;
    float timer = 0;
    bool isThree = false;
    private void Start()
    {
        anim = GetComponentInChildren<AnimatorPlay>();
        base.Init();
    }
        /// <summary>
    /// 主武器攻击方式
    /// </summary>
    public override void AttackSkill_0(GameObject go)
    {
        if (anim.currentAnimName==AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.swordAttack_0);
            PrimaryWeaponsAttack0();
        }
    }

    public override void AttackSkill_1(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.swordAttack_1);
            PrimaryWeaponsAttack1();
        }
    }

    public override void AttackSkill_2(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.swordAttack_2);
            PrimaryWeaponsAttack2();
        }
    }

    public override void AttackSkill_3(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.swordAttack_3);
            PrimaryWeaponsAttack3();
        }
    }


    /// <summary>
    /// 主武器攻击方式
    /// </summary>

    /// <summary>
    /// sword——普攻
    /// </summary>   
    public void PrimaryWeaponsAttack0()
    {
        if (Time.time-timer>1.4f)
        {
            anim.anim.SetFloat("PrimarySword", 0);
            timer = Time.time;
            isThree = false;
            StartCoroutine(SlashDely(0));
        }
        else if(Time.time - timer > 0.8f&& Time.time - timer < 1.4f)
        {
            if (!isThree)
            {
                anim.anim.SetFloat("PrimarySword", 0.5f);
                isThree = true;
                timer = Time.time;
                StartCoroutine(SlashDely(30));
            }
            else
            {
                anim.anim.SetFloat("PrimarySword", 1);
                isThree = true;
                timer = 0;
                StartCoroutine(SlashDely(90));
            }
        }
    }

    public IEnumerator SlashDely(float angle)
    {
        yield return new WaitForSeconds(0.3f);
        GameObject slash = pool.CreateObject("SlashPool", transform.position + new Vector3(-0.5f, 1, 1.5f), transform.rotation*Quaternion.Euler(0,0,angle));
        pool.MyDestory(slash, 0.4f);
    }




    /// <summary>
    /// sword——圆灭斩
    /// </summary>
    public void PrimaryWeaponsAttack1()
    {
        StartCoroutine(RoundDely());
    }
    public IEnumerator RoundDely()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject slash = pool.CreateObject("RoundPool", transform.position + transform.forward * 10 + transform.up, transform.rotation);
        pool.MyDestory(slash, 0.6f);
    }

    /// <summary>
    /// sword——月牙天冲
    /// </summary>
    /// <returns></returns>
    public void PrimaryWeaponsAttack2()
    {
        StartCoroutine(CrescentDely());
    }
    public IEnumerator CrescentDely()
    {
        yield return new WaitForSeconds(0.44f);
        GameObject crescent_0 = pool.CreateObject("CrescentPool", transform.position + Vector3.up * 0.2f, transform.rotation);
        crescent_0.GetComponent<Rigidbody>().velocity = transform.forward * 20;
        //crescent_0.transform.DOMove(transform.)
        pool.MyDestory(crescent_0, 1.2f);

        yield return new WaitForSeconds(0.4f);
        GameObject crescent_1 = pool.CreateObject("CrescentPool", transform.position + Vector3.up + transform.right * 0.5f, transform.rotation);
        crescent_1.transform.rotation *= Quaternion.Euler(0, 0, 90);
        crescent_1.GetComponent<Rigidbody>().velocity = transform.forward * 20;
        pool.MyDestory(crescent_1, 1.4f);

        yield return new WaitForSeconds(0.4f);
        GameObject crescent_2 = pool.CreateObject("CrescentPool", transform.position + Vector3.up * 2.4f + transform.right * 1.2f, transform.rotation);
        crescent_2.transform.rotation *= Quaternion.Euler(0, 0, 60);
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
        transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(ArrayDely());
    }

    public IEnumerator ArrayDely()
    {

        float attackRange = 5.2f;
        float swordCount = 8.0f;
        Transform[] sword = new Transform[(int)swordCount];
        GameObject ArraySword = pool.CreateObject("SwordArrayPool", transform.position + transform.forward * 18 + Vector3.up, transform.rotation);
        CameraView(12, 4, 44);
        for (int i = 0; i < sword.Length; i++)
        {
            sword[i] = ArraySword.transform.GetChild(0).GetChild(i);
            sword[i].DOMove(sword[0].parent.position + new Vector3(attackRange * Mathf.Cos(i * 2 * Mathf.PI / swordCount), 3, attackRange * Mathf.Sin(i * 2 * Mathf.PI / swordCount)), 1);
        }
        //获取剑阵中心半径为5的范围内的敌人
        Collider[] colliders = Physics.OverlapSphere(ArraySword.transform.position, 5);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                colliders[i].GetComponent<EnemyState>().OnDamage(GetComponent<PlayerState>().attack);
                enemy= colliders[i].GetComponent<BaseFSM>();
                enemy.isBeAttack = true;
                print(enemy.isBeAttack);
                print(colliders[i].name);
            }
        }
        //ArraySword.transform.DORotate(ArraySword.transform.eulerAngles + 360 * Vector3.up, 1);
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
        transform.DOMove(sword[2].position - Vector3.up * 3, 0.3f);
        yield return new WaitForSeconds(0.3f);
        anim.PlayAnim(AnimationName.swordAttackend_3);
        for (int i = 0; i < sword.Length; i++)
        {
            sword[i].localPosition = Vector3.zero;
        }
        transform.GetChild(1).gameObject.SetActive(false);
        if (enemy !=null)
        {
            enemy.isBeAttack = false;
            enemy.PlayAnimation(AnimationName.idle);
        }
        pool.MyDestory(ArraySword);
    }

    private void Update()
    {
        Debug.DrawLine(transform.position + transform.forward * 3, transform.position + transform.forward * 3 + Vector3.up * 10, Color.red);

    }
}
