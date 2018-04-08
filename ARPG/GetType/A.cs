using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyTest;
using System;
using System.Reflection;

public class A : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //原有的实例化方式
        //  B b = new B();
        //1.获取当前类型的对象
        Type type = Type.GetType("MyTest.B");
        //2.获取当前类当中的所有公开方法
        // MethodInfo[] info= type.GetMethods();
        System.Object obj = Activator.CreateInstance(type);

        MethodInfo info = type.GetMethod("BTest");
        info.Invoke(obj,null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
