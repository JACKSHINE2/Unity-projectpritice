using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理所有需要被监听的子物体UI
/// </summary>
public class UIScene : MonoBehaviour {

    /// <summary>
    /// 管理所有需要被监听的子物体
    /// </summary>
    public Dictionary<string, UIEventListener>
    listener = new Dictionary<string, UIEventListener>();
	public void Start () {
      
        Init();
      
	}
    /// <summary>
    /// 根据名字在字典当中获取子物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public UIEventListener GetTrigger(string name)
    {
        if (listener.ContainsKey(name))
            return listener[name];
        return null;

    }
    public T GetTrigger<T>(string name) where T:Component
    {
        UIEventListener item=   GetTrigger(name);
     if (item != null)
         return item.transform.GetComponent<T>();
     return null;
    }
	public void Init()
    {
        FindChildTrigger(transform);

    }
    /// <summary>
    /// 寻找所有带有UITriggerListener的子物体
    /// </summary>
    public void FindChildTrigger(Transform  t)
    {
        //如果他自身有监听组件且不为null的话
        //UITirggerListener trigger = t.GetComponent<UITirggerListener>();
        //if (trigger != null&&!listener.ContainsKey(trigger.name))
        //{
        //    //添加到字典当中
        //    listener.Add(trigger.name, trigger);
        //}
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    FindChildTrigger(transform.GetChild(i));

        //}
        UIEventListener trigger = t.GetComponent<UIEventListener>();
        if (trigger != null)
        {
            string name = t.gameObject.name;
            if (!listener.ContainsKey(name))
            {
                listener.Add(name, trigger);
            }
            else
            {
            }
        }
        for (int i = 0; i < t.childCount; ++i)
        {
            Transform child = t.GetChild(i);
            FindChildTrigger(child);
        }

    }
}
