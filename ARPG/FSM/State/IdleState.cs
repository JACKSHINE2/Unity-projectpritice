using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM {
    public class IdleState : FSMState{
        public override void Action(BaseFSM fsm)
        {
            //播放动画
            fsm.PlayAnimation(AnimationName.idle);
            Debug.Log("进入Idle状态");
        }

        public override void Init()
        {
            stateID = FSMStateID.Idle;
        }

    }
}
