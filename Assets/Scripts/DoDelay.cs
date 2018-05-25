
using System.Collections;
using UnityEngine;
using System;

/// <summary>
/// 延迟操作的工具类
/// </summary>
public static class DoDelay {

   public static void CreateActive(MonoBehaviour mono,float time,Action action)
    {
        mono.StartCoroutine(Do(time, action));
    }

    static IEnumerator Do(float time,Action action)
    {
        yield return new WaitForSeconds(time);
        action();
        yield break;
    }
}