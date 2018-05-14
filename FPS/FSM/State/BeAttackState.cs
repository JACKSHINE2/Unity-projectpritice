using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM
{
    public class BeAttackState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {

        }

        public override void Init()
        {
            stateID = FSMStateID.BeAttacking;
        }

        public override void OnStateEnter(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.beAttack);
        }

        public override void OnStateExit(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.idle);
        }

        // Use this for initialization

    }
}
