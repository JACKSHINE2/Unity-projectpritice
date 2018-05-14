using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public abstract class SkillBase :MonoBehaviour{
    public BulletPool pool;
    public AnimatorPlay anim;
    public abstract void AttackSkill_0(GameObject go);
    public abstract void AttackSkill_1(GameObject go);
    public abstract void AttackSkill_2(GameObject go);
    public virtual void AttackSkill_3(GameObject go) { }
    public virtual void ShiftWeapon(GameObject go) { }

    // Use this for initialization

    public void Init()
    {
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
    }

        /// <summary>
    /// 视角改变
    /// </summary>
    public void CameraView(int height, int away, float angle)
    {
        Camera.main.GetComponent<ThirdPersonCamera>().enabled = false;
        Camera.main.transform.DOMove(transform.position + Vector3.up * height - transform.forward * away, 1.4f);
        Camera.main.transform.DORotate(transform.eulerAngles + transform.right * angle, 0.4f);
    }

}
