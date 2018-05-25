using UnityEngine;

public class AK12: MonoBehaviour, IWeapon
{

    public const int MaxBulletNum = 30;//一个弹夹的子弹容量
    public const int MaxMagazineNum = 5;//玩家最大可持弹夹数量
    private int m_currentBulletNum = MaxBulletNum;//当前子弹数量
    private int m_currentMagazineNum = MaxMagazineNum;//当前弹夹数量
    [Range(1,10)]
    public const float Speed = 3f;//射速

    private float shootInterval = 0.1f;//每一发子弹与上一发子弹的间隔时间

    private float tempInterval;//变量，计算间隔时间
    private float lastTime = 0;//变量，记载上一发子弹发射时的游戏时间

    private bool isSingleFire = true;//是否为单发模式

    private GameObject FireEffect;//枪火特效

    private AK12Animation ak12Ani;
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

    private void Awake()
    {
        FireEffect = this.transform.Find("FireEffect").gameObject;
        FireEffect.SetActive(false);
        ak12Ani = this.GetComponent<AK12Animation>();
    }


    private void OnEnable()
    {
        Player.Instance.currentWeapon = this;
    }




    public void Fire()
    {
        m_currentBulletNum = MaxBulletNum;//开挂代码


        if (m_currentBulletNum == 0) //如果没有子弹了，不允许执行下面的方法
            return;

        shootInterval = 0.5f / Speed;//计算一个射击间隔时间

        tempInterval = Time.time - lastTime;//计算上一发间隔时间
        if (tempInterval > shootInterval) //判断是否大于预算间隔时间
        {
            lastTime = Time.time;//保存上一发的时间

            m_currentBulletNum--;//当前子弹数量--
            //播放一次枪火特效
            FireEffect.SetActive(false);
            FireEffect.SetActive(true);
            //播放一次动画
            ak12Ani.Shoot();
            //播放一次音效

            //生成一个弹壳

            //判断是否打到碰撞体，如果碰撞，生成一个弹痕
            ShowImpactEffect();
        }
    }

    /// <summary>
    /// 显示弹痕特效
    /// </summary>
    void ShowImpactEffect()
    {
        if (RayController.Instance.IsCast)
        {
            RaycastHit hit = RayController.Instance.raycastHit;
            string _tag = hit.transform.gameObject.tag;
            //通过射线碰撞物体的tag标签来获取相应的弹痕特效object
            //GameObject _impactEffect = ImpactEffectManager.Instance.GetImpactEffect(_tag);

            //获取一个特效
            GameObject _impactEffect = ImpactEffectManager.Instance.GetBrickEffect();
            _impactEffect.transform.position = hit.point;
            _impactEffect.transform.rotation = Quaternion.identity;
            //让弹痕特效看向碰撞物体的纹理方向
            _impactEffect.transform.LookAt(hit.normal + hit.point);

            _impactEffect.SetActive(true);
        }
    }

    /// <summary>
    /// 更换弹夹
    /// </summary>
    public void Reload()
    {
        if (m_currentMagazineNum > 0)
        {
            m_currentMagazineNum--;
            m_currentBulletNum = MaxBulletNum;
        }
    }

    /// <summary>
    /// 更换发射模式
    /// </summary>
    public void ChangeFireMode()
    {
        if (isSingleFire)
            isSingleFire = false;
        else
            isSingleFire = true;
    }



}