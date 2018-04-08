using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    /// <summary>
    /// 圆形攻击 
    /// </summary>
    public class CircleAttackMode : ISelectAttackMode
    {
        public GameObject[] SelectTarget(SkillData skillData, Transform skillTransform)
        {

            //场景当中所有的目标 相应标签的目标   
            //用圆形射线在当前技能周围找出在攻击距离范围之内的所有碰撞
            Collider[] colliders =
                Physics.OverlapSphere(skillTransform.position,
                skillData.attackDistance);
            //从所有碰撞体当中找出所有的敌人,相应标签的敌人且是活的
            Collider[] collidersTarget =
                Array.FindAll(colliders, p =>
      Array.IndexOf(skillData.attackTargetTags, p.tag) >= 0 &&
      p.GetComponent<CharacterState>().hp > 0);
            //如果没有找到目标，返回
            if (collidersTarget == null || collidersTarget.Length == 0)
                return null;
            GameObject[] targets = CollectionHelper.Select(collidersTarget,
               p => p.gameObject);
            // GameObject target = null;
            //如果是单体攻击，返回该数组当中最近的元素
            if (skillData.attackType == SkillAttackType.Single)
            {
                // Array.Find
                //排序算法
                CollectionHelper.OrderBy(targets, p => Vector3.
        Distance(skillTransform.position, p.transform.position));
                //群体
                return new GameObject[] { targets[0] };


            }
            return targets;
        }

    }
}
