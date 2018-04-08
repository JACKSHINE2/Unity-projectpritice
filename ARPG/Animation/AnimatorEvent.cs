using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour {
    private AnimatorPlay anim;
    public void Start()
    {
        anim =
           GetComponent<AnimatorPlay>();
    }
    public void RunEvent()
    {
        anim.PlayAnim(AnimationName.normal);
    }
}
