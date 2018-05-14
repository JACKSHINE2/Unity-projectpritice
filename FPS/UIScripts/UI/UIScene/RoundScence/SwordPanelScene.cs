using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPanelScene : UIScene {
    UIEventListener swordAttack_0;
    UIEventListener swordAttack_1;
    UIEventListener swordAttack_2;
    UIEventListener swordAttack_3;
    public SwordAttack sword;
    // Use this for initialization
    void Start () {
        base.Start();
        swordAttack_0 = GetTrigger("SwordAttack_0");
        swordAttack_1 = GetTrigger("SwordAttack_1");
        swordAttack_2 = GetTrigger("SwordAttack_2");
        swordAttack_3 = GetTrigger("SwordAttack_3");

        swordAttack_0.onClick += transform.GetChild(0).GetComponent<CoolTime>().FillAll;
        swordAttack_0.onClick += sword.AttackSkill_0;

        swordAttack_1.onClick += transform.GetChild(1).GetComponent<CoolTime>().FillAll;
        swordAttack_1.onClick += sword.AttackSkill_1;

        swordAttack_2.onClick += transform.GetChild(2).GetComponent<CoolTime>().FillAll;
        swordAttack_2.onClick += sword.AttackSkill_2;

        swordAttack_3.onClick += transform.GetChild(3).GetComponent<CoolTime>().FillAll;
        swordAttack_3.onClick += sword.AttackSkill_3;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
