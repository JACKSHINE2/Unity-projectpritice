using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色马达（负责角色的移动控制）
/// </summary>
public class CharacterMotor : MonoBehaviour {

    private CharacterState state;
    private AnimatorPlay anim;
    private void Start()
    {
        state = GetComponent<CharacterState>();
        anim = GetComponentInChildren<AnimatorPlay>();
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
        }
       


    }
    /// <summary>
    /// 转向方法
    /// </summary>
    /// <param name="hor">水平轴</param>
    private void RotationC(float hor)
    {
        transform.Rotate(new Vector3(0, hor, 0)*Time.deltaTime* state.rotationSpeed);
    }


    public void MoblieMove(float x, float y)
    {
        if (Mathf.Abs(x) < 1 && Mathf.Abs(y) < 1)
        {
            //anim.PlayAnim(AnimationName.idle);
            FloatSetting(0, 0);
        }
        else
        {
            if (x > 1 && Mathf.Abs(x) > Mathf.Abs(y))
                FloatSetting(1, 0);

            //anim.PlayAnim(AnimationName.runRight);
            else if (x < -1 && Mathf.Abs(x) > Mathf.Abs(y))
                FloatSetting(-1, 0);

            //anim.PlayAnim(AnimationName.runLeft);
            else if (y > 1 && Mathf.Abs(y) > Mathf.Abs(x))
                FloatSetting(0, 1);

            //anim.PlayAnim(AnimationName.runForward);
            else if (y < -1 && Mathf.Abs(y) > Mathf.Abs(x))
                //anim.PlayAnim(AnimationName.runBack);
                FloatSetting(0, -1);
            anim.PlayAnim(AnimationName.Motion);
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(x, 0, y).normalized * state.moveSpeed, Time.deltaTime);
        }
    }

    public void FloatSetting(float a,float b)
    {
        anim.anim.SetFloat("PosX", a);
        anim.anim.SetFloat("PosY", b);
    }
}



public enum RunningType
{
   PC,
   Mobile,
}
