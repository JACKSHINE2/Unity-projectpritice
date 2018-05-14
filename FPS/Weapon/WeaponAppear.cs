using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAppear : MonoBehaviour {
    Dictionary<string, GameObject> weaponCache = new Dictionary<string, GameObject>();
    Transform player;
    bool isShow=false;
    BulletPool pool;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pool = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BulletPool>();
        AddCache();
    }



    public void AddCache()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                Transform obj = transform.GetChild(i).GetChild(j);
                weaponCache.Add(obj.name, obj.gameObject);
                obj.gameObject.SetActive(false);
            }
        }
    }

    public void SelectWeaponAppear()
    {
        weaponCache[GameLevel.weaponGet].SetActive(true);
        weaponCache[GameLevel.weaponGet.Substring(0,1)+"Shine"].SetActive(true);
        isShow = true;
    }


    private void Update()
    {
        if (weaponCache[GameLevel.weaponGet].activeSelf)
        {
            weaponCache[GameLevel.weaponGet].transform.Rotate(Vector3.up, Time.deltaTime * 60);
        }
        if (Vector3.Distance(player.position, transform.position) < 18 && isShow)
        {
            GameObject weapon = weaponCache[GameLevel.weaponGet];
            pool.CreateObject("WeaponGetPool", player.GetChild(0).GetChild(1).position, player.rotation);
            weaponCache[GameLevel.weaponGet.Substring(0, 1) + "Shine"].SetActive(false);
            player.GetComponentInChildren<WeaponBag>().WeaponUpgradet();
            isShow = false;
            weapon.SetActive(false);
        }
    }
}
