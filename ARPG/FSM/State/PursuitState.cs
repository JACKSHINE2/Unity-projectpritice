using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class PursuitState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {
            fsm.MoveToTarget();
        }

        public override void Init()
        {
            stateID = FSMStateID.Pursuit;
        }
    }
}
