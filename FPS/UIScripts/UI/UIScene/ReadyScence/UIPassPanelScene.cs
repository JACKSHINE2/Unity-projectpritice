using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPassPanelScene : UIScene {
    UIEventListener round_1;
    UIEventListener round_2;
    UIEventListener round_3;
    UIEventListener round_4;
    UIEventListener round_5;
    // Use this for initialization
    void Start () {
        base.Start();
        GetTrigger("ReturnButton").onClick += ReturnButtonOnClick;
        round_1 = GetTrigger("Round1");
        round_2 = GetTrigger("Round2");
        round_3 = GetTrigger("Round3");
        round_3 = GetTrigger("Round4");
        round_3 = GetTrigger("Round5");
        round_1.onClick += Loading1;
        round_2.onClick += Loading2;
        round_3.onClick += Loading3;
        round_3.onClick += Loading4;
        round_3.onClick += Loading5;
    }
	
    void ReturnButtonOnClick(GameObject go){

        UIManager.instance.IsActive("PassPanel",false);
    }
    public void Loading1(GameObject go)
    {
        GameLevel.roundName = "Scenes/Round1";
        SceneManager.LoadScene("Scenes/Loading");
    }
    public void Loading2(GameObject go)
    {
        GameLevel.roundName = "Scenes/Round2";
        SceneManager.LoadScene("Scenes/Loading");
    }
    public void Loading3(GameObject go)
    {
        GameLevel.roundName = "Scenes/Round3";
        SceneManager.LoadScene("Scenes/Loading");
    }
    public void Loading4(GameObject go)
    {
        GameLevel.roundName = "Scenes/Round4";
        SceneManager.LoadScene("Scenes/Loading");
    }
    public void Loading5(GameObject go)
    {
        GameLevel.roundName = "Scenes/Round5";
        SceneManager.LoadScene("Scenes/Loading");
    }


}
