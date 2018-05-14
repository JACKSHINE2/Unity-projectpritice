using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AI.FSM
{
    public class StartEnemyAnim : MonoBehaviour
    {
        BaseFSM baseFSM;
        // Use this for initialization
        void Start()
        {
            baseFSM = GetComponent<BaseFSM>();
            StartCoroutine(EnemyMove());
            StartCoroutine(FSMStart());
        }

        public IEnumerator EnemyMove()
        {
            yield return new WaitForSeconds(2);
            transform.DOMove(transform.position - transform.up * 4.4f + transform.forward * 3, 3);
        }

        public IEnumerator FSMStart()
        {
            yield return new WaitForSeconds(3.6f);
            baseFSM.enabled = true;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
