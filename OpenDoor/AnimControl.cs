using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour {
    Animator animator;
    public Transform rightHand;
    public Transform door;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        door = GameObject.FindWithTag("Finish").transform;
	}
	
	// Update is called once per frame
	void Update () {
        float ver = Input.GetAxis("Vertical");
        animator.SetBool("Walk", ver != 0);
        
	}
    private void OnAnimatorIK(int layerIndex)
    {
        if (Vector3.Distance(rightHand.position, transform.position) < 1.6f)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
            if (door.eulerAngles.y < 24)
            {
                door.RotateAround(new Vector3(0, 1, -0.8f), transform.up, 0.5f);
            }
        }
    }
}
