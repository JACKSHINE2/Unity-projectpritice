using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//技能模块
//敌人模块
/// <summary>
/// 播放动画
/// </summary>
public class AnimatorPlay : MonoBehaviour {
   
    /// <summary>
    /// 当前播放的动画
    /// </summary>
    public string currentAnimName=AnimationName.Motion;
    public Animator anim;
    public void Start()
    {       
        anim = GetComponent<Animator>();
        anim.speed = 2;
    }
    public void PlayAnim(string animName)
    {
        if (animName==currentAnimName)
        {
            return;
        }
        //停止上一个动画
         anim.SetBool(currentAnimName, false);
        currentAnimName = animName;
        //播放下一个动画
         anim.SetBool(currentAnimName, true);
    }
}
public struct AnimationName
{
    //站立
    public const string Motion = "Motion";
    public const string idle = "Idle";
    //移动
    public const string runForward = "RunForward";
    public const string runBack = "RunBack";
    public const string runRight = "RunRight";
    public const string runLeft = "RunLeft";
    //剑攻击
    public const string swordAttack_0 = "SwordAttack_0";
    public const string swordAttack_1 = "SwordAttack_1";
    public const string swordAttack_2 = "SwordAttack_2";
    public const string swordAttack_3 = "SwordAttack_3";
    public const string swordAttackend_3 = "SwordAttackend_3";


    //枪攻击
    public const string gunAttack_0 = "GunAttack_0";
    public const string gunAttack_1 = "GunAttack_1";
    public const string gunAttack_2 = "GunAttack_2";
    public const string gunAttack_3 = "GunAttack_3";

    //受伤
    public const string beAttack = "BeAttack";

    //死亡
    public const string death = "Death";

    //切换武器
    public const string shiftWeapon = "ShiftWeapon";

    //跳跃
    public const string jump = "Jump";
}
