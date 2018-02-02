using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Appearance : MonoBehaviour {
    public GameObject tankPrefab;
    public Text score;
    public Text message;
    private float timer;
    GameObject player_1;
    GameObject player_2;
    int count=0;
    

    // Use this for initialization
    void Start () {
            GetComponent<AudioSource>().Play();
            player_1 = Instantiate(tankPrefab, Vector3.left, Quaternion.Euler(0, 90, 0));
            player_1.tag = "Player1";
            player_2 = Instantiate(tankPrefab, Vector3.right * 10, Quaternion.identity);
            player_2.tag = "Player2";
            //player_2.GetComponent<Renderer>().material.color = Color.blue;

            player_2.GetComponent<TankController>().ho = "Horizontal2";
            player_2.GetComponent<TankController>().ve = "Vertical2";
            player_2.GetComponent<TankController>().fire = KeyCode.Backspace;
            score.text = "Round" + Score.roundCount + "\n" + Score.score_1 + " : " + Score.score_2;
            message.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {      
        //print(Score.roundCount+"  ,  "+Score.nextScence.ToString());
        ///第一回合之后，enter键切换到下一回合，显示RoundCount标题2秒，最后标题消失
        if (count==0)
        {
            timer = Time.time;
            count++;
            message.text = "Round " + Score.roundCount+" / " + Score.inputNumber;            
        }
        if (Time.time > timer + 2&&count==1)
        {
            message.gameObject.SetActive(false);
            count++;
        }


        if (Score.nextScence&&Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(0);        
            Score.nextScence = false;           
        }       
	}
}
