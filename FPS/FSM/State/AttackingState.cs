using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    public class AttackingState : FSMState
    {
        float timer = 0;
        public override void Action(BaseFSM fsm)
        {
            timer += Time.deltaTime;
            if (timer>4)
            {
                fsm.enemySkill.SeletSkill();
                timer = 0;
            }
        }
        public override void OnStateEnter(BaseFSM fsm)
        {
            fsm.enemySkill.SeletSkill();
        }
        public override void OnStateExit(BaseFSM fsm)
        {
            fsm.PlayAnimation(AnimationName.idle);
        }

        public override void Init()
        {
            stateID = FSMStateID.Attacking;

        }
    }
}
