using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour {
    public AudioClip exploreClip;
    public float speed;
    private Rigidbody mRigidbody;
    public ParticleSystem exploration;
    // Use this for initialization
    void Start () {
        mRigidbody = GetComponent<Rigidbody>();
        //mRigidbody.AddForce(transform.forward * 10,ForceMode.Impulse);
        mRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update () {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag[6] != gameObject.tag[6])
        {
            ParticleSystem explor = Instantiate(exploration, transform.position, Quaternion.identity);
            explor.Play();
            Destroy(gameObject);
        }
        //Collider[] collider = Physics.OverlapSphere(transform.position,0.5f);
        //for (int i = 0; i < collider.Length; i++)
        //{
        //    collider[i].GetComponent<Rigidbody>().AddExplosionForce(1,transform.position,0.5f);
        //}

    }
}
