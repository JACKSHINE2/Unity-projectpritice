using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0.为所有需要监听的UI添加UITriggerListener
//1.挂载UIInit  Init当中的方法不做更改
//2.在UISceneName当中为所有的UIPanel添加常量名
//3.在UIManager当中的ShowUI方法中显示一级界面
//4.为所有要进行界面操控的Panel添加UIScene的派生类


/// <summary>
/// 进行UI初始化
/// </summary>
public class UIInit : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        UIManager.instance.Init();
        
        UIManager.instance.ShowUI();
	}
	
}
