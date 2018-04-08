using Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSkillManager : MonoBehaviour
{
    // 管理多个技能数据对象---容器List<SkillData> 所有技能
  
    public List<SkillData> skills = new List<SkillData>();
    //角色拥有者的状态信息
    private CharacterState chState;
    //1.初始化   :初始化技能信息
    //对象池
    private ISelectAttackMode attackMode;
    public void Start()
    {
        chState = GetComponent<CharacterState>();
     
        foreach (var item in skills)
        {
            //24byte
            //加载技能预制体
            if (item.skillPerfab == null
                && !string.IsNullOrEmpty(item.perfabName))
            {
                item.skillPerfab = Resources.Load<GameObject>("Skill/" +
                    item.perfabName);
                
            }
            //加载该技能在受击方的预制体
            if (item.hitFxPrefab == null
      && !string.IsNullOrEmpty(item.hitFxName))
            {
                item.hitFxPrefab = Resources.Load<GameObject>("Skill/" +
                    item.hitFxName);
            }
        }
        #region 测试技能使用
        //   //准备技能
        //  SkillData currentData= PrepareSkill(1);
        //   print(currentData.damageMode + "AttackMode");
        //   //获取当前技能攻击类型的算法（圆形，扇形，矩形）
        //   attackMode = Activator.CreateInstance(
        //    Type.GetType("Skill."+currentData.damageMode + "AttackMode"))
        //     as ISelectAttackMode;
        // //  attackMode = new CircleAttackMode();
        //   //调用算法
        //GameObject[] objs=   attackMode.SelectTarget(currentData, transform);
        //   for (int i = 0; i < objs.Length; i++)
        //   {
        //       print("当前攻击目标为" + objs[i].name);
        //   }
        #endregion
    }

    //2.准备技能  在技能池当中找到可以能释放的技能
    public SkillData PrepareSkill(int id)
    {
        //找到skills当中id为当前传入id的对象
        SkillData skillData =
            skills.Find(p => p.skillID == id);
        //for (int i = 0; i < skills.Count; i++)
        //{
        //    if (skills[i].skillID == id)
        //        return skills[i];
        //}
        //如果当前技能不为空且当前技能释放者
        //sp>=当前技能释放所需要的sp且当前技能
        //剩余冷却时间为0
        if (skillData != null && chState.sp >= skillData.costSp
            && skillData.coolRemain == 0)
        {
            skillData.Onwer = gameObject;
            return skillData;
        }
        return null;
    }
    //3.施放技能
    public void DeploySkill(SkillData skillData)
    {
        //创建技能预制件  对象池
        GameObject skillObj =
            Instantiate(skillData.skillPerfab,
            transform.position, transform.rotation);
        //进行技能释放  使用产品
        SkillDeployer skillDeployer
            = skillObj.GetComponent<SkillDeployer>();
        //告诉工厂我们所需要加工的技能原材料
        skillDeployer.skillData = skillData;
        //释放技能（使用加工好的该产品进行技能释放）
        skillDeployer.DeployerSkill();
        //销毁  对象池
        if (skillData.duiationTime>1)
        Destroy(skillObj, skillData.duiationTime);
        else
            Destroy(skillObj, 1);
        CoolTimeDown(skillData);
    }


    //4.技能冷却处理
    public IEnumerator CoolTimeDown(SkillData skillData)
    {
        skillData.coolRemain = skillData.coolTime;
        while (skillData.coolRemain>0)
        {
            yield return new WaitForSeconds(1);
            skillData.coolRemain -= 1;
        }
        skillData.coolRemain = 0;
    }
    //5.获取技能冷却剩余时间
    public float GetSkillCoolRemain(int id)
    {
        return skills.Find(p => p.skillID == id).coolRemain;
    }
}
