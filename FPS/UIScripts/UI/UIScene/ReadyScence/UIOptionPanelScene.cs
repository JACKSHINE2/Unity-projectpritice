using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionPanelScene : UIScene {

    private void Start()
    {
        base.Start();
        GetTrigger("ReturnButton").onClick += ReturnButtonOnClick;

    }

    void ReturnButtonOnClick(GameObject go){

        this.GetComponent<TweenPosition>().PlayReverse();
    }

}
