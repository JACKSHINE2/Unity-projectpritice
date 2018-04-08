using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    /// <summary>
    /// 目标选择的算法（圆形，扇形，矩形）
    /// </summary>
    public interface ISelectAttackMode
    {

        GameObject[] SelectTarget(SkillData skillData,
            Transform skillTransform);

    }
}
