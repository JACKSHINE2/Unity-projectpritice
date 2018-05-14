using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;


/// <summary>
/// 角色的抽象信息（保存所有角色所需要的变量信息）
///    属性字段    动画系统  移动系统
/// </summary>
public class CharacterState : MonoBehaviour {
    [HideInInspector]
    /// <summary>
    /// 视野范围
    /// </summary>
    public float viewRange;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 转向速度
    /// </summary>
    public float rotationSpeed;
    /// <summary>
    /// 血量
    /// </summary>
    public float hp;
    /// <summary>
    /// 蓝量
    /// </summary>
    public float sp;
    /// <summary>
    /// 攻击力
    /// </summary>
    public float attack;
    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attackRange;
    /// <summary>
    /// 防御力
    /// </summary>
    public float defend;
    public string currentSword;
    public string currentGun;

    public AnimatorPlay anim;
    public UISlider hpSlider;
    public void Start()
    {
       // print(gameObject.name + "的血量为:" + hp);
        //加载受击点
        anim =  GetComponentInChildren<AnimatorPlay>();
        hpSlider = GetComponentInChildren<UISlider>();
    }
    public void OnDamage(float attack)
    {
        float realAttack = attack - defend;
        realAttack = realAttack <= 1 ? 1 : realAttack;
        hp -= realAttack;
        hpSlider.value = hp / 100.0f;
        if (hp <= 0)
            Death();
    }

    public virtual void  Death()
    {
        //播放死亡动画
        anim.PlayAnim(AnimationName.death);
        //销毁物体  对象池
      
    }

    public void ReadData(string tableName)
    { 
        string[] data;
        //数据库的链接对象
        string path = "Player.db";
        path = "URI=file:" + Application.streamingAssetsPath + "/" + path;
        DbAccess dbAccess = new DbAccess(path);
        SqliteDataReader reader;
        reader= dbAccess.ReadFullTable(tableName);
        data = new string[reader.FieldCount];

        for (int i = 0; i < reader.FieldCount; i++)
        {
            data[i] = reader.GetValue(i).ToString();
            print(data[i]);
        }
        dbAccess.CloseSqlConnection();
        //playerName = data[0];
        hp = int.Parse(data[0]);
        sp = int.Parse(data[1]);
        attack = int.Parse(data[2]);
        defend = int.Parse(data[3]);
        attackRange = int.Parse(data[4]);
        viewRange = int.Parse(data[5]);
        moveSpeed = int.Parse(data[6]);
        rotationSpeed = int.Parse(data[7]);
        //currentSword = data[8];
        //currentGun = data[9];
    }

    public void SaveData(string tableName)
    {
        //数据库的链接对象
        SqliteConnection sql;
        string path = "Player.db";
        //读取对象
        SqliteDataReader reader;
        SqliteCommand command;
        //1.将mono.data.dll  system.data   sqlite3.dll放入Plugins文件夹当中
        //2.路径需要加"URI=file"  "Data Source="
        //3.链接数据库  并打开
        //4.执行sql语句
        //5。发布移动端时需要在playersettings当中修改.net2.0subset为.net2.0
        //6.string类型的数据在写入数据当中除了""号之外要加''
        path = "URI=file:" + Application.streamingAssetsPath + "/" + path;
        sql = new SqliteConnection(path);
        //打开数据库  流
        sql.Open();
        //声明数据库语句对象
        command = sql.CreateCommand();
        //command.CommandText = "Insert Into Student (ID,Name) values (129,'Jack')";
        command.CommandText = "UPDATE "+tableName+" SET" +"currentSword = "+ currentSword+",currentGun "+currentGun+" WHERE "+"playerName = James";

        //执行SQL语句 
        command.ExecuteNonQuery();
        command.Dispose();
        sql.Close();

    }
}
