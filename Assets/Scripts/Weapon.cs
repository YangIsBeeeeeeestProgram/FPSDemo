using UnityEngine;

public interface IWeapon {


    int CurrentBulletNum { get; }
    int CurrentMagazineNum { get; }
    bool IsSingleFire { get; set; }//是否为单发

    /// <summary>
    /// 发射
    /// </summary>
    void Fire();

    /// <summary>
    /// 更换弹夹
    /// </summary>
    void Reload();

    /// <summary>
    /// 更换发射模式
    /// </summary>
    void ChangeFireMode();
    
}