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
    public  AnimatorPlay anim;
    private CharacterMotor playerMotor;
    public RunningType runningType;
    public Transform MoveContent;

    // Use this for initialization
    void Start () {
        playerState = GetComponent<CharacterState>();
        playerMotor = GetComponent<CharacterMotor>();
        anim = GetComponentInChildren<AnimatorPlay>();

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
                playerMotor.MoblieMove(MoveContent.localPosition.x/10, MoveContent.localPosition.y/10);
                break;

        }

      


    }
}
