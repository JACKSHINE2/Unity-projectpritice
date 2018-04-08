using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    /// <summary>
    /// 扇形
    /// </summary>
    public class SectorAttackMode : ISelectAttackMode
    {
      
        public GameObject[] SelectTarget(SkillData skillData, Transform skillTransform)
        {
       
            //发射一个球形状射线，找到攻击半径内的所有碰撞体
            Collider[] colliders =
                  Physics.OverlapSphere(skillTransform.position,
                  skillData.attackDistance);
            //找出当前所有碰撞体当中目标物体
            //便签需要是目标便签，角度在扇形角度之内。得是活着的
            colliders = CollectionHelper.FindAll(colliders,
                p => Array.IndexOf(colliders, p.tag) >= 0
                && p.GetComponent<CharacterState>().hp > 0
                && Vector3.Angle(skillTransform.forward,
                p.transform.position - skillTransform.position
                ) <= skillData.attackAngle / 2);
            if (colliders.Length == 0 || colliders == null)
                return null;
            //GameObject[] targets = new GameObject[colliders.Length];
            //for (int i = 0; i < colliders.Length; i++)
            //{
            //    targets[i] = colliders[i].gameObject;
            //}
            //将collider转换为gameobject
            GameObject[] targets = CollectionHelper.Select(colliders,
                p => p.gameObject);
            if (skillData.attackType == SkillAttackType.Single)
            {
                //选择排序   //冒泡排序  hp  attack  sp   speed
                CollectionHelper.OrderBy(targets, p => Vector3.
                 Distance(skillTransform.position, p.transform.position));

                return new GameObject[] { targets[0] };
            }
            return targets;
          
        }
    
    }
}
