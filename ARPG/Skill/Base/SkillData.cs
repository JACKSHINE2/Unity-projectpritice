
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能对象 代表每一个技能（技能的原材料和需要加工的工具）
/// </summary>
[System.Serializable]
public class SkillData  {
    //    技能ID，(skillID )
    public int skillID;
    //技能名称(name)
    public string skillName;
    //技能描述(description)
    public string description;
    //冷却时间(coolTime)
    public float coolTime;
    //冷却剩余(coolRemain)
    public float coolRemain;
    //魔法消耗(costSP)
    public float costSp;
    //攻击距离(attackDistance)
    public float attackDistance;
    //攻击角度(attackAngle)
    public float attackAngle;
    //攻击目标tags[] , (attackTargetTags)
    public string[] attackTargetTags;
    //攻击目标对象数组(attackTargets)
    [HideInInspector]
    public GameObject[] attackTargets;
    //连击的下一个技能编号(nextBatterId)
    //伤害比率(damage)
    public float damage;
    //持续时间(durationTime)
    public float duiationTime;
    //伤害间隔(damageInterval)
    public float damageInterval;
    //技能所属（Onwer），
    public GameObject Onwer;
    //技能预制件名称(perfabName)
    public string perfabName;
    //预制件对象(skillPerfab)
    [HideInInspector]
    public GameObject skillPerfab;
    //动画名称(animationName)
    public string animationName;
    //受击特效名称(hitFxName)
    public string hitFxName;
    //受击特效对象(hitFxPerfab)
    public GameObject hitFxPrefab;
    //等级(level)
    public int level;
    //是否激活（activated）
    public bool activated;
    //技能类型(SkillAttackType attackType) ：单攻Single，群攻Group
    public SkillAttackType attackType;
    //伤害模式(DamageMode damageMode) ：圆形Circle，扇形Sector矩形Rectangle
    public DamageMode damageMode;
}
public enum SkillAttackType
{
    /// <summary>
    /// 单体
    /// </summary>
    Single,
    /// <summary>
    /// 群体
    /// </summary>
    Group,
}
public enum DamageMode
{
    /// <summary>
    /// 圆形
    /// </summary>
    Circle,
    /// <summary>
    /// 扇形
    /// </summary>
    Sector,
    /// <summary>
    /// 矩形
    /// </summary>
    Rectangle,
}
