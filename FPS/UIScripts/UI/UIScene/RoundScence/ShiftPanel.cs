using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftPanel : UIScene {
    public Transform weapon;
    AnimatorPlay anim;
    int number = 0;
    UIEventListener shift;
	// Use this for initialization
	void Start () {
        base.Start();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AnimatorPlay>();
        shift = GetTrigger("ShiftWeapon");
        shift.onClick += GetComponentInChildren<CoolTime>().FillAll;
        shift.onClick += Shift;
    }
	


    public void Shift(GameObject go)
    {
        if (anim.currentAnimName == AnimationName.Motion)
        {
            anim.PlayAnim(AnimationName.shiftWeapon);

            ++number;
            if (number % 2 == 0)
            {

                IsSword(true);
            }
            else
            {
                IsSword(false);
            }
        }
        else
        {
            print("只有非战斗状态才能切换武器");
        }

    }


    public void IsSword(bool isAppear)
    {
        UIManager.instance.IsActive("SwordPanel", isAppear);
        UIManager.instance.IsActive("GunPanel", !isAppear);
        weapon.GetChild(0).gameObject.SetActive(isAppear);
        weapon.GetChild(1).gameObject.SetActive(!isAppear);
    }


}
