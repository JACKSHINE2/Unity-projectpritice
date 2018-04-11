using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Skill
{
    /// <summary>
    /// 技能工厂
    /// </summary>
    public class SelectorFactory
    {
     static   Dictionary<string, ISelectAttackMode>
            cache = new Dictionary<string, ISelectAttackMode>();
        /// <summary>
        /// 根据伤害模式提供相应的伤害算法
        /// </summary>
        /// <param name="modo"></param>
        /// <returns></returns>
        public static ISelectAttackMode 
            CreatDamageMode(DamageMode modo)
        {
            if (!cache.ContainsKey(modo.ToString()))
            //命名空间
            {
                string classNameSpace = typeof(SelectorFactory).Namespace;
                //类名
                string attackTypeName =string.Format("{0}AttackMode", modo.ToString());
                //反射需要的命名空+类名
                attackTypeName = classNameSpace +"."+attackTypeName;
                //通过反射获取类型
                cache.Add(modo.ToString(),Activator.CreateInstance(Type.GetType(attackTypeName)) as ISelectAttackMode);
            }
            return cache[modo.ToString()];
        }

    }
}
