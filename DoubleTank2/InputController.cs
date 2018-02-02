using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    int a = 0;
    //public GameObject tank;
    //public GameObject follow;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (a==0 && Score.inputNumber!=0)
        {
            print(Score.inputNumber);

            a++;
        }
        if ((Score.inputNumber>0 || Score.roundCount>1 )&& a==1)
        {
            GetComponent<Appearance>().enabled = true;
            Camera.main.GetComponent<Follow>().enabled = true;
            a++;
            GameObject.FindWithTag("Finish").SetActive(false);
        }

	}

    public  void InputEnd(string str)
    {
        Score.inputNumber = int.Parse(str);
    } 

}
