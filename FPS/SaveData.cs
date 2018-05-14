using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SaveData : MonoBehaviour {
    CharacterState charater;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(string tableName)
    {
        string[] data;
        //数据库的链接对象
        string path = "Player.db";
        path = "URI=file:" + Application.streamingAssetsPath + "/" + path;
        DbAccess dbAccess = new DbAccess(path);
        SqliteDataReader reader;
        reader = dbAccess.ReadFullTable(tableName);
        data = new string[reader.FieldCount];

        for (int i = 0; i < reader.FieldCount; i++)
        {
            data[i] = reader.GetValue(i).ToString();
            print(data[i]);
        }
        dbAccess.CloseSqlConnection();
        //playerName = data[0];
        charater.hp = int.Parse(data[0]);
        charater.sp = int.Parse(data[1]);
        charater.attack = int.Parse(data[2]);
        charater.defend = int.Parse(data[3]);
        charater.attackRange = int.Parse(data[4]);
        charater.viewRange = int.Parse(data[5]);
        charater.moveSpeed = int.Parse(data[6]);
        charater.rotationSpeed = int.Parse(data[7]);
    }
}
