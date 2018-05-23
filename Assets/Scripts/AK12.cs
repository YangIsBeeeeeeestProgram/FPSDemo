using UnityEngine;

public class AK12: MonoBehaviour, IWeapon
{

    public const int MaxBulletNum = 30;//一个弹夹的子弹容量
    public const int MaxMagazineNum = 5;//玩家最大可持弹夹数量
    private int m_currentBulletNum = MaxBulletNum;//当前子弹数量
    private int m_currentMagazineNum = MaxMagazineNum;//当前弹夹数量
    [Range(1,10)]
    public const float Speed = 2.5f;//射速

    private float shootInterval = 0.1f;//每一发子弹与上一发子弹的间隔时间

    private float tempInterval;//变量，计算间隔时间
    private float lastTime = 0;//变量，记载上一发子弹发射时的游戏时间

    private bool isSingleFire = true;
    public bool IsSingleFire
    {
        get
        {
            return isSingleFire;
        }

        set
        {
            isSingleFire = value;
        }
    }

    public int CurrentBulletNum { get { return m_currentBulletNum; } }
    public int CurrentMagazineNum { get { return m_currentMagazineNum; } }

    private void OnEnable()
    {
        Player.Instance.currentWeapon = this;
    }




    public void Fire()
    {
        print("1");
        if (m_currentBulletNum == 0) //如果没有子弹了，不允许执行下面的方法
            return;

        shootInterval = 0.5f / Speed;//计算一个射击间隔时间

        tempInterval = Time.time - lastTime;//计算上一发间隔时间
        if (tempInterval > shootInterval) //判断是否大于预算间隔时间
        {
            m_currentBulletNum--;//当前子弹数量--
            //播放一次枪火特效
            //播放一次动画
            //播放一次音效
            //生成一个弹壳
            //判断是否打到碰撞体，如果碰撞，生成一个弹痕
        }
    }



}