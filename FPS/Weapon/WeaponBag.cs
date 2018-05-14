 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponBag : MonoBehaviour {
    public PlayerState player;
    Dictionary<string, Dictionary<string, GameObject>> weaponDic = new Dictionary<string, Dictionary<string, GameObject>>();
    string sword = "Sword";
    string gun = "Gun";

    /// <summary>
    /// 初始化背包
    /// </summary>
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        WeaponAdd(sword);
        WeaponAdd(gun);
        print(player.currentGun);
        weaponDic[sword][player.currentSword].SetActive(true);
        weaponDic[gun][player.currentGun].SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void WeaponAdd(string weaponType)
    {
        if (weaponDic.ContainsKey(weaponType)) return;
        weaponDic.Add(weaponType, new Dictionary<string, GameObject>());
        Transform weaponCache;
        weaponCache = transform.Find(weaponType);        
        for (int i = 0; i < weaponCache.childCount; i++)
        {
            weaponDic[weaponType].Add(weaponCache.GetChild(i).name, weaponCache.GetChild(i).gameObject);
            weaponCache.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 根据武器名称，获取类型
    /// </summary>
    /// <param name="weaponName"></param>
    /// <returns></returns>
    public string WeaponType(string weaponName) {
        if (weaponDic[gun].ContainsKey(weaponName)) return gun;
        else return sword;
    }

    public string NextWeapon( )
    {
        int isSword = Random.Range(0, 2);
        if (isSword == 0)
        {
            return player.currentSword.Substring(0, 6) + (player.currentSword[6] -'0'+1);
        }
        return player.currentGun.Substring(0, 4) + (player.currentGun[4] - '0'+1);
    }

    /// <summary>
    /// 过关获取武器,替换原来的武器
    /// </summary>
    public void WeaponUpgradet()
    {
        if (WeaponType(GameLevel.weaponGet) == gun)
        {
            weaponDic[gun][player.currentGun].SetActive(false);
            weaponDic[gun][GameLevel.weaponGet].SetActive(true);
            player.currentGun = GameLevel.weaponGet;
        }
        else if (WeaponType(GameLevel.weaponGet) == sword)
        {
            weaponDic[sword][player.currentSword].SetActive(false);
            weaponDic[sword][GameLevel.weaponGet].SetActive(true);
            player.currentSword = GameLevel.weaponGet;
        }
        GameLevel.weaponGet = NextWeapon();
    }




}
