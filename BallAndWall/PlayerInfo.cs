using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo{
    public int remainingCount=5;
    private PlayerInfo() { }
    private static PlayerInfo instance;
    public static PlayerInfo Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new PlayerInfo();
            }
            return instance;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
