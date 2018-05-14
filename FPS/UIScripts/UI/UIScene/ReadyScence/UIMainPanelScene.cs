using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainPanelScene : UIScene {

	// Use this for initialization
	void Start () {
        base.Start();
        GetTrigger("SelectHeroButton").onClick += SelectHeroButtonOnClick;
        GetTrigger("OptionButton").onClick += OptionButtonOnClick;
        GetTrigger("SelectPassButton").onClick += SelectPassButtonOnClick;
	}

    void SelectPassButtonOnClick(GameObject go){
        UIManager.instance.IsActive("PassPanel",true);
    }


    void OptionButtonOnClick(GameObject go){

        UIManager.instance.scenes["OptionPanel"].GetComponent<TweenPosition>().PlayForward();
    }

    void SelectHeroButtonOnClick(GameObject go)
    {
        UIManager.instance.scenes["SelectHeroPanel"].GetComponent<TweenPosition>().PlayForward();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
