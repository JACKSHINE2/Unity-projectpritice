using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            return fsm.chState.hp <= 0;
        }

        

        protected override void Init()
        {
            triggerID = FSMTriggerID.NoHealth;
        }
    }
}
