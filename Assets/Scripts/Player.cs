using UnityEngine;
using System.Collections.Generic;
public class Player: Singleton<Player> {

    public IWeapon currentWeapon;

  
    public int MAX_HP = 100;
    public int HP = 100;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        print(HP);
        if (HP <= 0)
        {
            HP = 0;
        }
    }

    /// <summary>
    /// 检测是否射击到敌人
    /// </summary>
    public void DetectionFire()
    {
        if (RayController.Instance.IsCast)
        {
            RaycastHit hit = RayController.Instance.raycastHit;
            GameObject obj = hit.transform.gameObject;
            List<Enemy> enemies = EnemyController.Instance.enemies;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].obj == obj)
                {
                    enemies[i].Die();
                }
            }
        }
    }


}