using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour {
    public float coolTime;
    UITexture coolMask;
    public AnimatorPlay anim;
    bool pressAble = true;

    // Use this for initialization
    void Awake () {
        coolMask = transform.GetChild(0).GetComponent<UITexture>();        
        //UIEventListener.Get(gameObject).onClick = FillAll;
        coolMask.fillAmount = 0;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AnimatorPlay>();
	}
	

    public void FillAll(GameObject go) {
        if (anim.currentAnimName==AnimationName.Motion)
        {
            coolMask.fillAmount = 1;
            GetComponent<BoxCollider>().enabled = false;
            pressAble = true;
        }
       
    }

    // Update is called once per frame
    void Update () {
        if (coolMask.fillAmount > 0)
        {
            coolMask.fillAmount -= Time.deltaTime * (1 / coolTime);
        }
        if (coolMask.fillAmount == 0 && pressAble)
        {

            GetComponent <BoxCollider>().enabled = true;
            pressAble = false;
        }
    }
}
