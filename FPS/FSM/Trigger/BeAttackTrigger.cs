using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class BeAttackTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            return fsm.isBeAttack;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.BeAttack;
        }
        // Use this for initialization
    }
}
