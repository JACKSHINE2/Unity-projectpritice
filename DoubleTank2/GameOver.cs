using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    Text gameOver;
	// Use this for initialization
	void Start () {
        gameOver = transform.GetChild(0).GetComponent<Text>();


    }

    // Update is called once per frame
    void Update () {
        print(Score.roundCount);
        if (Score.roundCount == Score.inputNumber+1 &&Score.inputNumber!=0)
        {
            if (Score.score_1 > Score.score_2)
            {
                gameOver.text = "GameOver" + "\n"+ "\n" + "Player1  Win";
            }
            else if (Score.score_1 == Score.score_2)
            {
                gameOver.text = "GameOver" + "\n" + "\n" + "Draw";
            }
            else
            {
                gameOver.text = "GameOver" + "\n" + "\n" + "Player2  Win";
            }

        }
    }
}
