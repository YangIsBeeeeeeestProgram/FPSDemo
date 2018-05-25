using UnityEngine;
using System;
using System.Collections.Generic;
/// <summary>
/// 对象池
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> {

    //生成物体的方法的委托
    Func<T> generateFunc;
    //保存对象的池
    List<T> pool;
    //每次生成的个数
    int everCount = 5;


    /// <summary>
    /// 对象池构造函数
    /// </summary>
    /// <param name="_func">生成方法</param>
    /// <param name="initNum">初始化生成个数</param>
	public ObjectPool(Func<T> _func,int initNum)
    {
        generateFunc = _func;
        pool = new List<T>();
        //初始化生成initNum个数个T类型的对象，并将对象放入list池中
        for (int i = 0; i < initNum; i++)
        {
            T newT = _func();//执行生成物体方法

            pool.Add(newT);//添加到对象池中
        }
    }

    /// <summary>
    /// 从对象池中获取一个类型为T的实例
    /// </summary>
    /// <returns>返回T对象</returns>
    public T GetT()
    {
        //判断对象池中元素个数是否已经低于或等于1
        if (pool.Count <= 1)
        {
            //补充对象池中元素的个数
            for (int i = 0; i < everCount; i++)
            {
                T newT = generateFunc();
                pool.Add(newT);
            }
        }
        //获取对象池list集合中的0索引元素，并从集合中剔除
        T returnT = pool[0];
        pool.Remove(returnT);

        return returnT;
    }

    /// <summary>
    /// 回收元素放入池中
    /// </summary>
    /// <param name="t"></param>
    public void SetT(T t)
    {

        if (!pool.Contains(t))
            pool.Add(t);
    }
}