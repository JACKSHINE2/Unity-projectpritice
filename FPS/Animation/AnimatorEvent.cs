using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour {
    private AnimatorPlay anim;
    public void Start()
    {
        anim = GetComponent<AnimatorPlay>();
    }
    /// <summary>
    /// 玩家结束动画
    /// </summary>
    public void IdleEvent()
    {
        anim.PlayAnim(AnimationName.Motion);
    }
    /// <summary>
    /// 敌人结束
    /// </summary>
    public void EnemyIdleEvent ()
    {
        anim.PlayAnim(AnimationName.idle);
    }


}
