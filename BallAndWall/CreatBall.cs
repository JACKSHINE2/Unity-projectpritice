using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;






public class CreatBall : MonoBehaviour {
    private GameObject ballPrefab;
    private Vector3 startPoint;
	// Use this for initialization
	void Start () {
        startPoint = Camera.main.transform.position + Camera.main.transform.forward * 5;
        ballPrefab = Resources.Load<GameObject>("Ball");
        NewBall();
	}

    private void Update()
    {
        if (Input .GetKeyDown(KeyCode.Return)&&PlayerInfo.Instance.remainingCount<=0)
        {
            PlayerInfo.Instance.remainingCount = 5;
            SceneManager.LoadScene(0);
        }
    }


    void NewBall() {
        if (PlayerInfo.Instance.remainingCount > 0)
        {
            GameObject ball = Instantiate(ballPrefab, startPoint, Quaternion.identity);
            ball.GetComponent<BallScript>().disapearEvent += NewBall;
            PlayerInfo.Instance.remainingCount--;
        }
        else
        {
            print("Game over!Press the enter button to restart");
        }
    }
}
