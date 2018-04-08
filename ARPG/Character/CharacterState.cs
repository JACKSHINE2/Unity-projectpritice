using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色的抽象信息（保存所有角色所需要的变量信息）
///    属性字段    动画系统  移动系统
/// </summary>
public class CharacterState : MonoBehaviour {
    public string hitName;
    //受击中点位置
    [HideInInspector]
    public Transform hitPos;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 转向速度
    /// </summary>
    public float rotationSpeed;
    /// <summary>
    /// 血量
    /// </summary>
    public float hp;
    /// <summary>
    /// 蓝量
    /// </summary>
    public float sp;
    /// <summary>
    /// 攻击力
    /// </summary>
    public float attack;
    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attackRange;
    /// <summary>
    /// 防御力
    /// </summary>
    public float defult;
    public AnimatorPlay anim;
    public void Start()
    {
       // print(gameObject.name + "的血量为:" + hp);
        //加载受击点
        if(!string.IsNullOrEmpty(hitName))
        hitPos = transform.Find(hitName);
        anim = 
            GetComponentInChildren<AnimatorPlay>();
    }
    public void OnDamage(float attack)
    {
        float realAttack = attack - defult;
        realAttack = realAttack <= 1 ? 1 : realAttack;
        hp -= realAttack;
        if (hp <= 0)
            Death();
    }

    public void Death()
    {
        print(gameObject.name+"死亡方法");
        //播放死亡动画
        anim.PlayAnim(AnimationName.death);
        //销毁物体  对象池
      
    }
}
