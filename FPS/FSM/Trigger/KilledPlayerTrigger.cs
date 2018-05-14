using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class KilledPlayerTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            return fsm.target.GetComponent<CharacterState>().hp <= 0;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.KilledPlayer;
        }
    }
}
