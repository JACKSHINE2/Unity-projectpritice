using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM
{
    public class SawPlayerTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            //返回目标与当前状态机挂载对象的距离
            return Vector3.Distance(fsm.target.position,fsm.transform.position) <= fsm.chState.viewRange;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.SawPlayer;
        }
    }
}
