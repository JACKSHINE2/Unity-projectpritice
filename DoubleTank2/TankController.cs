using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankController : MonoBehaviour {
    public int HP=3;
    private Rigidbody mRigidbody;
    public float moveSpeed=10;
    public float angleSpeed=25;
    private float smooth=10;
    public string ho= "Horizontal1";
    public string ve= "Vertical1";
    public GameObject bullet;
    private AudioSource moveAudio;

    private AudioClip tankClip;
    public AudioClip shotClip;
    public AudioClip explorationClip;

    public ParticleSystem exploration;
    public KeyCode fire = KeyCode.Space;
    string playerTag;
    public  float power;
	// Use this for initialization
	void Start () {
        mRigidbody = GetComponent<Rigidbody>();
        moveAudio = GetComponent<AudioSource>();
        moveAudio.Play();
        moveAudio.volume = 0;
        playerTag = gameObject.tag[6].ToString();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        tankClip = audioSource.clip;
    }
   
    private void FixedUpdate()        
    {       
        ///坦克移动和旋转   
        float hor = Input.GetAxis(ho);
        float ver = Input.GetAxis(ve);
        mRigidbody.AddForce(transform.forward*moveSpeed*ver*Time.fixedDeltaTime,ForceMode.Impulse);
        mRigidbody.rotation *=Quaternion.Euler(0,hor*angleSpeed*Time.fixedDeltaTime,0) ;
        if (ver!=0)
        {
            moveAudio.volume = 0.6f;
        }
        else
        {
            moveAudio.volume = 0;
        }

        ///坦克普通射击特效
        if (Input.GetKeyDown(fire))
        {
            CreateBullet(0);
        }
        ///坦克蓄力射击
        if (Input.GetKey(fire) && power<2)
        {
            power += Time.fixedDeltaTime;            
        }
        if (power>0.4 && power<2&& Input.GetKeyUp(fire))
        {            
            CreateBullet(power);
            power = 0;                    
        }        
        else if (power<0.4&&Input.GetKeyUp(fire))
        {
            power = 0;
        }
        else if (power>2)
        {
            CreateBullet(power);
            power = 0;
        }
        
    }
    

    // Update is called once per frame
    void Update () {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag[6]!=collision.gameObject.tag[6]&&collision.gameObject.tag.Contains("bullet"))
        {
            --HP;
            if (HP == 0&&!Score.nextScence)
            {
                tankClip = explorationClip;
                ParticleSystem expor= Instantiate(exploration, transform.position, Quaternion.identity);
                expor.Play();
                Destroy(expor,1);
                Score.roundCount++;
                if (gameObject.tag == "Player1")
                {
                    Score.score_2 += 200;
                }
                else
                {
                    Score.score_1 += 200;
                }
                Score.nextScence = true;
                Destroy(gameObject);
            }
        }
    }
    
    void CreateBullet(float power)
    {
        //AudioSource.PlayClipAtPoint(shotClip, transform.position);
        tankClip = shotClip;
        GameObject obj= Instantiate(bullet, transform.position + Vector3.up * 1.5f, transform.rotation);
        obj.tag = "bullet" + playerTag;
        obj.GetComponent<BulletShot>().speed += power * 8;
        
    }
    

}
