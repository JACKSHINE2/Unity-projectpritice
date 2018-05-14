using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UISceneName
{
    public const string Panel_login = "Panel_Login";
    public const string Panel_ChooseAndEnter = "Panel_ChooseAndEnter";
    public const string Panel_CreateCharacter = "Panel_CreateCharacter";
    public const string Panel_Main = "Panel_Main";
    public const string Panel_Close = "Panel_Close";
}
public class UIManager : MonoSingleton<UIManager> {
    public int scenceIndex;
    public Dictionary<string, UIScene> scenes = new Dictionary<string, UIScene>();
    public void Init()
    {
        //GameObject.FindObjectsOfType(typeof())
        //无法强行转换成GameObject
        //找到所有挂载有UIScene脚本的物体
        //直接可以将类型转换
        UIScene[] items = GameObject.FindObjectsOfType<UIScene>();
   
        for (int i = 0; i < items.Length; i++)
        {
            //吧Object转换成GameObject
           // GameObject go = (GameObject)items[i] ;

            UIScene go = items[i];
            if (!scenes.ContainsKey(go.name))
            { 
                //将挂载有UIScene的游戏对象增加到管理的字典当中
                scenes.Add(go.name, go);
                go.gameObject.SetActive(false);
            }
        }
          
    }
    /// <summary>
    /// 开启和关闭Panel
    /// </summary>
    /// <param name="name">Panel名称</param>
    /// <param name="isActive">开启或者关闭</param>
    public void IsActive(string name,bool isActive)
    { 
        GameObject go=scenes[name].gameObject;
        if (go == null)
        {
            Debug.LogError("你要查的东西丢了");
            return;
        }
        go.SetActive(isActive);
        //if (go.activeSelf && !isActive)
        //{
        //    go.SetActive(false);
        //}
    }
    /// <summary>
    /// 开启一级界面
    /// </summary>
    public void ShowUI()
    {
        if (scenceIndex == 1) 
        {
            IsActive("SwordPanel", true);
            IsActive("ShiftPanel", true);
        }
        else if (scenceIndex == 0)
        {
            IsActive("BackGround", true);
            IsActive("SelectHeroPanel", true);
            IsActive("OptionPanel", true);
        }
        
    }
}
