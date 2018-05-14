using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunPanelScene :UIScene {

    UIEventListener gunAttack_0;
    UIEventListener gunAttack_1;
    UIEventListener gunAttack_2;
    UIEventListener gunAttack_3;

    public GunAttack gun;
    // Use this for initialization
    void Start () {
        base.Start();
        gunAttack_0 = GetTrigger("GunAttack_0");
        gunAttack_1 = GetTrigger("GunAttack_1");
        gunAttack_2 = GetTrigger("GunAttack_2");
        gunAttack_3 = GetTrigger("GunAttack_3");

        gunAttack_0.onClick += transform.GetChild(0).GetComponent<CoolTime>().FillAll;
        gunAttack_0.onClick += gun.AttackSkill_0;

        gunAttack_1.onClick += transform.GetChild(1).GetComponent<CoolTime>().FillAll;
        gunAttack_1.onClick += gun.AttackSkill_1;

        gunAttack_2.onClick += transform.GetChild(2).GetComponent<CoolTime>().FillAll;
        gunAttack_2.onClick += gun.AttackSkill_2;

        gunAttack_3.onClick += transform.GetChild(3).GetComponent<CoolTime>().FillAll;
        gunAttack_3.onClick += gun.AttackSkill_3;

    }
    private void OnDisable()
    {
       
    }
    // Update is called once per frame

}
