using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class AttackingState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {
            fsm.chSkill.RangeDeploySkill();

        }

        public override void Init()
        {
            stateID = FSMStateID.Attacking;
        }
    }
}
