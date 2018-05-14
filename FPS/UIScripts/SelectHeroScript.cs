using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

//选择英雄类 实现界面选择英雄功能
//存储Hero对象
//显示当前选择Hero,显示相应Hero信息
//切换显示Hero 
//确认切换、更新信息
public class SelectHeroScript : MonoBehaviour {

    static List<GameObject> list = new List<GameObject>();

    static string SureHeroName;

    static int currentPanelActiveHeroNum;

    static int SureHeroNum;

    private void Awake()
    {
        GameObject []items = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < items.Length; i++)
        {
            list.Add(items[i]);
            list[i].SetActive(false);
            if (i == 0) list[i].SetActive(true);
        }
    }


    public static void SelectHeroButton( ){
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(false);
        }
        list[SureHeroNum].SetActive(true);
        currentPanelActiveHeroNum = SureHeroNum;
        UpdateHeroMessage(list[currentPanelActiveHeroNum].name);
    }

    public static void MakeSureButton(){
        SureHeroName = list[currentPanelActiveHeroNum].name;
        SureHeroNum = currentPanelActiveHeroNum;
       
    }

    public static void ShowHeroToLeft(GameObject go){
        int n = currentPanelActiveHeroNum - 1;
        if(n < 0){
            n = list.Count - 1;
        }
        ShowHero(n);
        currentPanelActiveHeroNum = n;
    }

   public static void ShowHeroToRight(GameObject go){
        int n = currentPanelActiveHeroNum + 1;
        if (n > list.Count - 1)
        {
            n = 0;
        }
        ShowHero(n);
        currentPanelActiveHeroNum = n;
    }

   static void ShowHero(int n){
        //隐藏上一个、显示下一个
        list[currentPanelActiveHeroNum].SetActive(false);
        list[n].SetActive(true);

    }

  
    static void UpdateHeroMessage(string HeroName){
        DbAccess db = new DbAccess("Data Source = " + Application.streamingAssetsPath + "/Player.db");
        SqliteDataReader reader = db.Select("PlayerState","attack","10");
        //把信息写入相应Label
        string message = null;
        for (int i = 1; i < reader.FieldCount; i++)
        {
            message += (reader.GetName(i).ToString() + " : " + reader.GetValue(i).ToString()
                        + "\n");
        }
        UIManager.instance.scenes["SelectHeroPanel"].transform.Find("HeroMessagePanel")
                 .Find("HeroMessageLabel").GetComponent<UILabel>().text = message;

        db.CloseSqlConnection();
    }



}
