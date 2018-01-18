using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCoins : MonoBehaviour {
    private GameObject coinPrefab;
    private GameObject empty;
    private float timer;
    private float timeMagnitute;
    private float a;
    private int b;
    private Rigidbody mRigidbody;

    public float speedForward;
    public float speedRight;

    // Use this for initialization
    void Start () {
        coinPrefab = Resources.Load<GameObject>("Coins");
        mRigidbody = GetComponent<Rigidbody>();
        empty = GameObject.Find("GameObject");
	}
    private void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.tag == "Magnitute")
        {
            Destroy(other.gameObject);
            empty.GetComponent<SphereCollider>().radius=3;
            timeMagnitute = 0;
        }
        else if (other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
         }
    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * hor * speedRight;
        mRigidbody.velocity = Vector3.forward * speedForward * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            mRigidbody.AddForce(Vector3.up,ForceMode.Impulse);
        }
    }


    // Update is called once per frame
    void Update () {


        timer += Time.deltaTime;
        if (timer>6)
        {
            a = Random.Range(5,8);
            b = Random.Range(-1, 1);

            Vector3 startPosition = new Vector3(b*3, transform.position.y, transform.position.z + a);
            GameObject coins = Instantiate(coinPrefab, startPosition, Quaternion.identity);
            Destroy(coins,8);
            timer = 0;
        }

        if (empty.GetComponent<SphereCollider>().radius == 3)
        {
            timeMagnitute += Time.deltaTime;
        }
        if (timeMagnitute>3)
        {
            timeMagnitute = 0;
            empty.GetComponent<SphereCollider>().radius = 0.5f;
        }
	}
}
