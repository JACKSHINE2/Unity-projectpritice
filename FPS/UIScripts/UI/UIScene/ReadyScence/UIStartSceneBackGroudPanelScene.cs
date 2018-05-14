using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class UIStartSceneBackGroudPanelScene : UIScene {

	// Use this for initialization
    void Start () {
        //UIManager.instance.IsActive("BackGorundPanel",true);
        base.Start();
        GetTrigger("StartGameButon").onClick += StartGameButtonOnClick;

	}
	
    AsyncOperation async;
    public UILabel lable;
    float temProcess;

    void StartGameButtonOnClick(GameObject go){
        lable.gameObject.SetActive(true);
        async = SceneManager.LoadSceneAsync("Scenes/MainUIScene");
        async.allowSceneActivation = false;
        GetTrigger("StartGameButon").GetComponent<TweenScale>().PlayForward();
        GetTrigger("StartGameButon").GetComponent<TweenAlpha>().PlayForward();
        StartCoroutine(Test());
    }

    IEnumerator Test(){

        while(temProcess < 96){

            lable.text = temProcess.ToString() + "%";
            temProcess = Convert.ToInt32(temProcess + 2.7f);
            yield return new WaitForEndOfFrame();

        }
        yield return new WaitForSeconds(1);
        lable.text  = "100%";
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;

    }

}
