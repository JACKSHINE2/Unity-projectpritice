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
        public override void OnStateEnter(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.runForward);
            fsm.audioSource.Play();
        }
        public override void OnStateExit(BaseFSM fsm)
        {
            fsm.audioSource.Stop();
            fsm.PlayAnimation(AnimationName.idle);
        }

        public override void Init()
        {
            stateID = FSMStateID.Pursuit;
        }
    }
}
