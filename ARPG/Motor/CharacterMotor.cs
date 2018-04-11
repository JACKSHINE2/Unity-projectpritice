using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色马达（负责角色的移动控制）
/// </summary>
public class CharacterMotor : MonoBehaviour {

    private CharacterState state;
    private void Start()
    {
        state = GetComponent<CharacterState>();
    }
    /// <summary>
    /// 移动方法
    /// </summary>
    /// <param name="hor">水平轴</param>
    /// <param name="ver">垂直轴</param>
    public void Move(float hor, float ver)
    {
        if (hor != 0 || ver != 0)
        {
            RotationC(hor);
            transform.Translate( Vector3.forward * Time.deltaTime  * state.moveSpeed *ver);
            state.anim.PlayAnim(AnimationName.run);
        }
       


    }
    /// <summary>
    /// 转向方法
    /// </summary>
    /// <param name="hor">水平轴</param>
    private void RotationC(float hor)
    {
        transform.Rotate(new Vector3( 0, hor, 0)*Time.deltaTime* state.rotationSpeed);
    }
}
public enum RunningType
{
   PC,
   Mobile,
}
