using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {
    public GameObject enemyExplosionPrefab;
    public AudioClip clip;
    private GameObject obj;
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Enemy")
        {
            obj.GetComponent<Score>().totalScore += 300;
            //播放爆炸效果
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            //添加音效
            AudioSource.PlayClipAtPoint(clip, other.transform.position);
            //移除自己
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
        
	}
}
