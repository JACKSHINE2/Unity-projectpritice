using System;
using System.Collections;
using UnityEngine;

namespace Skill
{
    public class SkillDeployer : MonoBehaviour
    {
        private SkillData m_skillData;
        private ISelectAttackMode attackMode;
        private CharacterState chState;
        public SkillData skillData
        {
            set
            {
                m_skillData = value;
                attackMode = SelectorFactory.CreatDamageMode(m_skillData.damageMode);
                chState = m_skillData.Onwer.GetComponent<CharacterState>();
            }
            get {
                return m_skillData;
            }
        }
      
        /// <summary>
        /// 对目标执行对于自身影响和对于敌方影响
        /// </summary>
        public virtual void DeployerSkill()
        {
            if (skillData == null)
                return;
            SelfImpact();
            StartCoroutine(ExecuteDamge());
        }
        /// <summary>
        /// 伤害算法
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator ExecuteDamge()
        {
            //记录敌人受到伤害的时间
            float attackTime = 0;
            //假设技能持续时间是10s  每次间隔1s
            do
            {
                //选择目标
                //给m_skillData.attackTargets赋值的过程
                ReseTargets();
                for (int i = 0; i < m_skillData.attackTargets.Length; i++)
                {
                    print("当前攻击目标为：" + m_skillData.attackTargets[i].name);
                    //对每一个目标进行目标影响算法
                    TargetImpact(m_skillData.attackTargets[i]);

                }
                //等待伤害间隔时间进行下一次伤害
                yield return new WaitForSeconds(skillData.damageInterval);
                attackTime += skillData.damageInterval;
            } while (m_skillData.duiationTime>attackTime);
        }

        private void ReseTargets()
        {
            if (m_skillData == null) return;
            m_skillData.attackTargets = attackMode.SelectTarget(m_skillData, transform);
        }

        /// <summary>
        /// 对于目标影响
        /// </summary>
        /// <param name="target">目标物体</param>
        public virtual void TargetImpact(GameObject target)
        {
            //target减血方法
            float attack = skillData.Onwer.GetComponent<CharacterState>().attack;
            //计算当前技能的真实攻击力
            float realAttack = attack * skillData.damage;
            CharacterState targetChState = target.GetComponent<CharacterState>();
            //调用目标身上的减血方法
            targetChState.OnDamage(realAttack);
            //产生受击点特效
            if (skillData.hitFxPrefab != null)
            {
                Transform targetHitPos = targetChState.hitPos;
                //对象池
                if (targetHitPos != null)
                {
                    GameObject go = Instantiate(skillData.hitFxPrefab, targetHitPos.position,targetHitPos.rotation);
                    Destroy(go, 0.1f);
                }                
            }
        }
        /// <summary>
        /// 对于自身的影响
        /// </summary>
        /// <param name="self"></param>
        public virtual void SelfImpact()
        {           
            chState.sp -= skillData.costSp;
        }

    }
}