using System;
using UnityEngine;

   public class MonoSingleton<T>:MonoBehaviour where T:Component
    {
       private static T t;
       public static T instance
       {
           get {
               t = GameObject.FindObjectOfType(typeof(T)) as T;
               if (t == null)
               {
                   GameObject go = new GameObject();
                   t = go.AddComponent<T>();
                
               }
               t.gameObject.name = t.name + "GameObject";
               return t;
           }
       }
    }

