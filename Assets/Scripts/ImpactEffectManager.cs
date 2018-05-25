using UnityEngine;
using System.Collections.Generic;

public class ImpactEffectManager: Singleton<ImpactEffectManager> {


    Dictionary<string, GameObject> impacts = new Dictionary<string, GameObject>();
    const string path = "Prefabs/Effects/";
    GameObject BrickImpactEffect;
    //对象池实例
    ObjectPool<GameObject> effPool;
    private void Awake()
    {
        Init();
    }



    void Init()
    {
        GameObject RockImpactEffect = Resources.Load(path + "RockImpactEffect") as GameObject;
        impacts.Add("Rock", RockImpactEffect);
        BrickImpactEffect = Resources.Load(path + "BrickImpactEffect") as GameObject;
        impacts.Add("Brick", BrickImpactEffect);

        //初始化对象池，传入参数生成方法func，和初始化生成个数5
        effPool = new ObjectPool<GameObject>(GenerateEffect, 5);

    }
    //生成特效的方法
    GameObject GenerateEffect()
    {
        GameObject newEff = Instantiate(BrickImpactEffect);
        newEff.SetActive(false);
        return newEff;
    }


    /// <summary>
    /// 获取一个弹痕特效
    /// </summary>
    public GameObject GetImpactEffect(string state)
    {
        return impacts[state];
    }


    public GameObject GetBrickEffect()
    {
        GameObject newObj = effPool.GetT();
        DoDelay.CreateActive(this, 3, new System.Action(() =>
          {
              newObj.SetActive(false);
              effPool.SetT(newObj);
          }));
        return newObj;
    }

}