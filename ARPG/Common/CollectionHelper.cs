using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionHelper {

    //通用性   
    //1.升序
    //public void OrderBy(int[] items)
    //{
    //    int temp;
    //    for (int i = 0; i < items.Length-1; i++)
    //    {
    //        for (int n = i+1; n < items.Length; n++)
    //        {
    //            if (items[i] > items[n])
    //            {
    //                temp = items[i];
    //                items[i] = items[n];
    //                items[n] = temp;
    //            }
    //        }
    //    }
    //}
    //T是单个类型基本类型   int  string float   GameObject  
    //                        CharacterState.hp
    //public void OrderBy<T>(T[] items) where T:IComparable<T>
    //{

    //    T temp;
    //    for (int i = 0; i < items.Length - 1; i++)
    //    {
    //        for (int n = i + 1; n < items.Length; n++)
    //        {
    //            if (items[i].CompareTo(items[n])>0)
    //            {
    //                temp = items[i];
    //                items[i] = items[n];
    //                items[n] = temp;
    //            }
    //        }
    //    }
    //}
    //                     T:CharacterState   Tkey:hp
    public  delegate Tkey SelectHandler<T, Tkey>(T t);
    //Tkey float   T  CharacterState
    //public static float Handler(CharacterState t)
    //{
    //    return Vector3.
    //             Distance(skillTransform.position, p.transform.position);
    //}
    //绑定一个方法

    public static  void OrderBy<T,TKey>(T[] items,
        SelectHandler<T,TKey> handler)where TKey:IComparable 
    {

        T temp;
        for (int i = 0; i < items.Length - 1; i++)
        {
            for (int n = i + 1; n < items.Length; n++)
            {
                if (handler(items[i]).CompareTo(handler(items[n])) > 0)
                {
                    temp = items[i];
                    items[i] = items[n];
                    items[n] = temp;
                }
            }
        }
    }

    //public static float Handler(CharacterState c)
    //{
    //    return c.hp;
    //}
    //public static void OrderBy(CharacterState[] items) 
    //{
    //    CharacterState temp;
    //    for (int i = 0; i < items.Length - 1; i++)
    //    {
    //        for (int n = i + 1; n < items.Length; n++)
    //        {
    //            if (Handler(items[i])>Handler(items[n]))
    //            {
    //                temp = items[i];
    //                items[i] = items[n];
    //                items[n] = temp;
    //            }
    //        }
    //    }
    //}
    //2.降序
    /// <summary>
    /// 降序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="items"></param>
    /// <param name="handler"></param>
    public static void OrderByDescending<T, TKey>(T[] items,
        SelectHandler<T, TKey> handler) where TKey : IComparable
    {
        T temp;
        for (int i = 0; i < items.Length - 1; i++)
        {
            for (int n = i + 1; n < items.Length; n++)
            {
                if (handler(items[i]).CompareTo(handler(items[n])) < 0)
                {
                    temp = items[i];
                    items[i] = items[n];
                    items[n] = temp;
                }
            }
        }
    }
    //3.查找
    public delegate bool FindHandler<T>(T t);
    //查找单个
    //public static CharacterState Find(CharacterState[] items)
    //{
    //    for (int i = 0; i < items.Length; i++)
    //    {
    //        if (items[i].hp <= 0)
    //            return items[i];
    //    }
    //    return null;
    //}
    /// <summary>
    /// 寻找单个
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static T Find<T>(T[] items, FindHandler<T> handler)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (handler(items[i]))
                return items[i];
        }
        return default(T);
    }
    //public static List<CharacterState> FindAll(CharacterState[] items)
    //{
    //    List<CharacterState> list = new List<CharacterState>();
    //    for (int i = 0; i < items.Length; i++)
    //    {
    //        if (items[i].hp <= 0)
    //            list.Add(items[i]);
    //    }
    //    return list.Count > 0 ? list : null;
    //}
    public static T[] FindAll<T>(T[] items,FindHandler<T>  handler)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < items.Length; i++)
        {
            if (handler(items[i]))
                list.Add(items[i]);
        }
        return list.Count > 0 ? list.ToArray() : null;
    }
    //4.选择
    //public static GameObject[] Select(Collider[] colliders)
    //{
    //    GameObject[] gameObjects = new GameObject[colliders.Length];
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        gameObjects[i] = colliders[i].gameObject;
    //    }
    //    return gameObjects;

    //}
    public static TKey[] Select<T, TKey>(T[] array,
        SelectHandler<T, TKey> handler)
    {
        TKey[] keys = new TKey[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            keys[i] = handler(array[i]);
        }
        return keys;
    }
}



