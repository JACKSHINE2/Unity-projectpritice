using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.AI;
using Skill;



/// <summary>
/// 有限状态机将AI的各种行为，独立封装成相应的状态对象
/// </summary>
/// 
namespace AI.FSM
{
    /// <summary>
    /// 状态机   中介者类  
    /// </summary>
    public  class BaseFSM :MonoBehaviour
    {
        public Transform target;
        public CharacterState chState;
        public NavMeshAgent navMeshAgent;
        public AnimatorPlay anim;
        public CharacterSkillSystem chSkill;
        //状态 条件 状态映射表
        private List<FSMState> stateList = new List<FSMState>();
        //当前状态
        private FSMState currentState;
        public FSMStateID currentStateID;
        //默认状态
        private FSMState defaultState;
        public FSMStateID defaultStateID;

        #region 进行各种初始化

        public void Awake()
        {
            InitReference();
            Init();
        }
        /// <summary>
        /// 初始化其他引用
        /// </summary>
        private void InitReference()
        {
            anim = GetComponentInChildren<AnimatorPlay>();
            chState = GetComponent<CharacterState>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            chSkill = GetComponent<CharacterSkillSystem>();


        }
        //当前的状态为Idle
        public void OnEnable()
        {
            DefaultInit();
        }
        /// <summary>
        /// 状态库和映射表等等的初始化，硬
        /// </summary>
        private void Init()
        {
            //进行状态实例化
            IdleState idle = new IdleState();
            PursuitState pursuit = new PursuitState();
            DeadState dead = new DeadState();
            AttackingState attack = new AttackingState();

            //添加相应状态的映射
            //Idle->SawPlayer->Pursuit
            idle.AddFsmMap(FSMTriggerID.SawPlayer, FSMStateID.Pursuit);
            //Idle->NoHealth->Dead
            idle.AddFsmMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            idle.AddFsmMap(FSMTriggerID.ReachPlayer, FSMStateID.Attacking);
            //pursuit->NoHealth->Dead
            pursuit.AddFsmMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            pursuit.AddFsmMap(FSMTriggerID.ReachPlayer, FSMStateID.Attacking);
            pursuit.AddFsmMap(FSMTriggerID.LosePlayer, FSMStateID.Idle);
            attack.AddFsmMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            attack.AddFsmMap(FSMTriggerID.WithOutAttack, FSMStateID.Pursuit);
            attack.AddFsmMap(FSMTriggerID.LosePlayer, FSMStateID.Idle);
            

            //在状态库当中添加状态
            stateList.Add(idle);
            stateList.Add(pursuit);
            stateList.Add(dead);
            stateList.Add(attack);
        }

        /// <summary>
        /// 默认状态初始化
        /// </summary>
        private void DefaultInit()
        {
            defaultState = stateList.Find(p => p.stateID == defaultStateID);
            currentState = defaultState;
            currentStateID = defaultState.stateID;
        }
        #endregion
                
       

        public void Update()
        {
            //当前状态的行为
            currentState.Action(this);
            //当前状态的条件检测
            currentState.Reason(this);
        }
        /// <summary>
        /// 状态切换
        /// </summary>
        
        public FSMState itemState;
        public void ChangeActiveState(FSMStateID stateID)
        {
            //将currentState改变为当前状态ID的状态
            //?stateID   ->state   反射
            //在状态库当中寻找相应状态ID的状态对象
            itemState = stateList.Find(p => p.stateID == stateID);
            //没有的话  返回
            if (itemState == null) return;
            //执行当退出当前状态方法
            currentState.OnStateExit(this);
            if (stateID == defaultStateID)
                currentState = defaultState;
            //如果不是默认状态且当前状态库当中有该状态
            //切换当前状态和当前状态的ID
            currentState = itemState;
            currentStateID = stateID;
            //执行当前状态的进入方法
            currentState.OnStateEnter(this);
        }

        #region 为条件和状态提供的方法
        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animName">动画名称</param>
        public void PlayAnimation(string animName)
        {
            anim.PlayAnim(animName);
        }
        public void MoveToTarget()
        {
            Debug.Log("开始追逐目标");
            navMeshAgent.SetDestination(target.position);
        }
        #endregion
    }

    /// <summary>
    /// 状态类，角色行为继承于它
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateID stateID;
        //状态->条件->状态的映射表
        private Dictionary<FSMTriggerID, FSMStateID> fsmMap = new Dictionary<FSMTriggerID, FSMStateID>();
        /// <summary>
        ///  条件列表 
        /// </summary>
        
        private List<FSMTrigger> triggerList = new List<FSMTrigger>();
        //添加映射表
        public void AddFsmMap(FSMTriggerID triggerID, FSMStateID stateID)
        {
            if (!fsmMap.ContainsKey(triggerID))
            {
                fsmMap.Add(triggerID, stateID);
                AddTriggerList(triggerID);
            }
            fsmMap[triggerID] = stateID;
        }
        //添加条件列表
        private void AddTriggerList(FSMTriggerID triggerID)
        {
            //反射，添加产品
            triggerList.Add((System.Activator.CreateInstance (Type.GetType("AI.FSM." + triggerID + "Trigger")) as FSMTrigger));
        }
        /// <summary>
        /// 删除映射表
        /// </summary>
        /// <param name="triggerID"></param>
        public void RemoveFsmMap(FSMTriggerID triggerID)
        {
            if (fsmMap.ContainsKey(triggerID))
            {
                fsmMap.Remove(triggerID);
                RemoveTriggerList(triggerID);
            }
        }
        private void RemoveTriggerList(FSMTriggerID triggerID)
        {
            triggerList.Remove(triggerList.Find
                (p => p.triggerID == triggerID));
        }
        /// <summary>
        /// 当前状态行为
        /// </summary>
        public abstract void Action(BaseFSM fsm);
        public FSMState()
        {
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public abstract void Init();
        /// <summary>
        /// 当进入当前状态
        /// </summary>
        /// <param name="fsm"></param>
        public virtual void OnStateEnter(BaseFSM fsm) { }
        /// <summary>
        /// 当退出当前状态
        /// </summary>
        /// <param name="fsm"></param>
        public virtual void OnStateExit(BaseFSM fsm) { }
        /// <summary>
        /// 条件检测
        /// </summary>
        public void Reason(BaseFSM fsm)
        {
            //?1.如何去将状态和对应条件关联起来
            //   状态->条件->状态
            //?2.条件列表
            //调用条件类当中的HandleTrigger

            for (int i = 0; i < triggerList.Count; i++)
            {
                //检测当前状态对应的条件是否满足
                if (triggerList[i].HandleTrigger(fsm))
                {
                    //ture  切换状态
                    //fsm.ChangActiveState()
                    fsm.ChangeActiveState(fsmMap[triggerList[i].triggerID]);
                }
            }
        }
    }

    /// <summary>
    /// 条件触发
    /// </summary>
    public abstract class FSMTrigger
    {
        public FSMTriggerID triggerID;
        /// <summary>
        /// 条件检测
        /// </summary>
        /// <returns></returns>
        public abstract bool HandleTrigger(BaseFSM fsm);

        public FSMTrigger()
        {
            Init();
        }
        protected abstract void Init();
    }

    public enum FSMTriggerID
    {
        SawPlayer,          //发现玩家	
        NoHealth,            //生命为0	
        ReachPlayer,       //玩家进入攻击范围	
        KilledPlayer,       //打死玩家	
        LosePlayer,         //玩家离开视野范围	
        WithOutAttack,    //玩家离开攻击范围
        PatrolComplete    //完成巡逻
    }

    public enum FSMStateID
    {
        Pursuit,        //追逐	
        Dead,           //死亡	
        Attacking,  //攻击	
        Patrolling,     //巡逻	
        Wander,         //徘徊	
        Idle,            //待机	  Idle-> SawPlayer-> Pursuit
        Default,        //默认
       
    }



}

