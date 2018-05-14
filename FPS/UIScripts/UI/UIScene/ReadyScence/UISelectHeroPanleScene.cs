using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectHeroPanleScene :UIScene {
    bool IsFirst = true;
	// Use this for initialization
	void Start () {
        
        base.Start();
        GetTrigger("SelectHeroLeftButton").onClick += SelectHeroScript.ShowHeroToLeft;
        GetTrigger("SelectHeroLeftButton").onClick += ShiftHero;
        GetTrigger("SelectHeroRightButton").onClick += SelectHeroScript.ShowHeroToRight;
        GetTrigger("SelectHeroRightButton").onClick += ShiftHero;
        GetTrigger("MakeSureButton").onClick += ReturnButtonOnClick;

	}


    void ReturnButtonOnClick(GameObject go){
        this.GetComponent<TweenPosition>().PlayReverse();
    }
	


    void ShiftHero(GameObject go)
    {
        if (IsFirst)
            GameLevel.heroMaterialIndex = 1;
        else
            GameLevel.heroMaterialIndex = 0;
        IsFirst = !IsFirst;
               
    }

	// Update is called once per frame
	void Update () {
        print(GameLevel.heroMaterialIndex);

    }
}
