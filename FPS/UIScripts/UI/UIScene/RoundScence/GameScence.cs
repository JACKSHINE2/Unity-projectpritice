using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScence : UIScene {

	// Use this for initialization
	void Start () {
        base.Start();
        GetTrigger("Close").onClick = ClosePanel_Close;
        GetTrigger("BackMain").onClick = BackMain;
        GetTrigger("Quit").onClick = Quit;

    }
	
    /// <summary>
    /// 关闭弹出框
    /// </summary>
    /// <param name="go"></param>
    public void ClosePanel_Close(GameObject go)
    {
        GetComponent<TweenWidth>().duration=0.1f;
        GetComponent<TweenWidth>().PlayReverse();

        Time.timeScale = 1;
        UIManager.instance.IsActive(UISceneName.Panel_Close, false);

    }

    /// <summary>                                                                                                                                                                                                  
    /// 返回主界面
    /// </summary>
    /// <param name="go"></param>
    public void BackMain(GameObject go)
    {
        GameLevel.roundName = "Scenes/MainUIScene";
        SceneManager.LoadScene("Scenes/Loading");
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    /// <param name="go"></param>
    public void Quit(GameObject go)
    {
        Application.Quit();
    }

    /// <summary>
    /// 弹出框
    /// </summary>
    /// <param name="go"></param>
    public void Open_Panel()
    {
        UIManager.instance.IsActive(UISceneName.Panel_Close, true);
        GetComponent<TweenWidth>().duration = 0.4f;
        GetComponent<TweenWidth>().PlayForward();
        Time.timeScale = 0;

    }
}
