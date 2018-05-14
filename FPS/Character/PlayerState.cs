using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class PlayerState : CharacterState
{
    public Texture[] texture;

    //1.将mono.data.dll  system.data   sqlite3.dll放入Plugins文件夹当中
    //2.路径需要加"URI=file"  "Data Source="
    //3.链接数据库  并打开
    //4.执行sql语句
    //5.发布移动端时需要在playersettings当中修改.net2.0subset为.net2.0
    //6.string类型的数据在写入数据当中 除了""号之外要加''
    private void Awake()
    {
        transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = texture[GameLevel.heroMaterialIndex];
        currentSword = "Sword_0";
        currentGun = "Gun_0";
    }
    public void Start()
    {
        base.Start();
        ReadData("PlayerState");
        //执行SQL语句 
    }

    public override void Death()
    {
        base.Death();
        UIManager.instance.IsActive(UISceneName.Panel_Close,true); 
    }



}
