using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 死亡状态
    /// </summary>
    public class DeadState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {
        }
        public override void OnStateEnter(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.death);
        }

        public override void Init()
        {
            stateID = FSMStateID.Dead;
        }

      
    }
}
