using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM {
    public class IdleState : FSMState{
        public override void Action(BaseFSM fsm)
        {
            //播放动画
        }

        public override void OnStateEnter(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.idle);
        }
        public override void Init()
        {
            stateID = FSMStateID.Idle;
        }

    }
}
