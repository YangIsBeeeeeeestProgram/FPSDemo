using UnityEngine;

public interface IWeapon {


    int CurrentBulletNum { get; }
    int CurrentMagazineNum { get; }
    bool IsSingleFire { get; set; }//是否为单发


    void Fire();
}