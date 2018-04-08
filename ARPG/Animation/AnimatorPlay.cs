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
    public string currentAnimName=AnimationName.idle;
    private Animator anim;
    public void Start()
    {
       
        anim = GetComponent<Animator>();
    }
    public void PlayAnim(string animName)
    {
        //停止上一个动画
         anim.SetBool(currentAnimName, false);
        print("停止上一个动画:" + currentAnimName);
        currentAnimName = animName;
        //播放下一个动画
         anim.SetBool(currentAnimName, true);
        print("播放下一个动画" +currentAnimName);
    }
}
public struct AnimationName
{
    public const string normal = "Idle";
    //站立
    public const string idle = "Idle";
    //跑步
    public const string run = "Run";
    //攻击
    public const string attack = "Attack";
    //死亡
    public const string death = "Death";
}
