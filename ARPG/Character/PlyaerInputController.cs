using Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家移动
/// 玩家攻击
/// 玩家动画播放
///
/// </summary>
public class PlyaerInputController : MonoBehaviour {
    private CharacterState playerState;
    private CharacterMotor playerMotor;
    private CharacterSkillSystem chSkillSystem;
    public RunningType runningType;

    // Use this for initialization
    void Start () {
        playerState = GetComponent<CharacterState>();
        playerMotor = GetComponent<CharacterMotor>();
        chSkillSystem = GetComponent<CharacterSkillSystem>();
    }

    float hor = 0;
    float ver = 0;
	void Update () {
        ///控制玩家移动
        switch (runningType)
        {
            case RunningType.PC:
                hor = Input.GetAxis("Horizontal");
                ver = Input.GetAxis("Vertical");
                playerMotor.Move(hor, ver);
                break;
            case RunningType.Mobile:
                print("移动端移动");
                break;

        }

        //玩家攻击和释放技能
        if (Input.GetKeyDown(KeyCode.A))
            chSkillSystem.AttackUseSkill(0);


    }
}
