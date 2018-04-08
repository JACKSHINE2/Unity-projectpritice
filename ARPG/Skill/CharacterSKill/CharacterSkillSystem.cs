using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    /// <summary>
    /// 外交类  中介类  通信类
    /// 技能和外部交互的桥梁
    /// </summary>
    public class CharacterSkillSystem : MonoBehaviour
    {
        //技能管理类
        private CharacterSkillManager skillManager;
        //角色状态类
        private CharacterState chState;
        //角色动画类
        private AnimatorPlay anim;
        //当前所使用的技能
        private SkillData currentSkillData;
        
        void Start()
        {
            skillManager = GetComponent<CharacterSkillManager>();
            chState = GetComponent<CharacterState>();
            anim = GetComponent<AnimatorPlay>();
        }
        public GameObject SelectTarget()
        {
            //场景当中所有的目标 相应标签的目标   
            //用圆形射线在当前技能周围找出在攻击距离范围之内的所有碰撞
            Collider[] colliders =
                Physics.OverlapSphere(transform.position,
                currentSkillData.attackDistance);
            //从所有碰撞体当中找出所有的敌人,相应标签的敌人且是活的
            Collider[] collidersTarget =
                Array.FindAll(colliders, p =>
      Array.IndexOf(currentSkillData.attackTargetTags, p.tag) >= 0 &&
      p.GetComponent<CharacterState>().hp > 0);
            //如果没有找到目标，返回
            if (collidersTarget == null || collidersTarget.Length == 0)
                return null;
            GameObject[] targets = CollectionHelper.Select(collidersTarget,
               p => p.gameObject);
            CollectionHelper.OrderBy(targets,
                p => Vector3.Distance(transform.position,
                p.transform.position));
            // GameObject target = null;
           
            
            return targets[0];
        }
        /// <summary>
        /// 随机释放技能
        /// </summary>
        public void RangeDeploySkill()
        {
            if (skillManager.skills == null ||
                skillManager.skills.Count == 0)
                return;
            int index = skillManager.skills.Count;
            AttackUseSkill
                (UnityEngine.Random.Range(0, index));
            //如果当前释放技能不存在。释放默认技能
            if (currentSkillData == null)
                AttackUseSkill(skillManager.skills[0].skillID);
        }
        private GameObject currentTarget;
        public void AttackUseSkill(int id)
        {
            //if(currentSkillData!=null)
            //准备技能
            currentSkillData =
                skillManager.PrepareSkill(id);
            if (currentSkillData == null)
                return;
            //释放技能
            skillManager.DeploySkill(currentSkillData);
            currentTarget = SelectTarget();
            //看向攻击目标
            if (currentTarget != null)
            {
                transform.LookAt(currentTarget.transform);
               //高光
               
            }
        }
       

    }
}