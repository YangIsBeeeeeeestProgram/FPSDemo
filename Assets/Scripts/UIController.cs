using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour {

    Text bulletNumText; //子弹数量ui
    Text magazineNumText;//弹夹数量ui
    Text fireModeText;//发射模式ui

    string bulletNumStr = string.Empty; //当前子弹数量string
    string magazineNumStr = string.Empty;//当前弹夹数量string
    string fireModeStr = string.Empty;//发射模式string
    private void Awake()
    {
        bulletNumText = this.transform.Find("BulletNumText").GetComponent<Text>(); //从子物体中找到ui对象并获取组件
        magazineNumText = this.transform.Find("MagazineNumText").GetComponent<Text>();//从子物体中找到ui对象并获取组件
        fireModeText = this.transform.Find("FireModeText").GetComponent<Text>();//从子物体中找到ui对象并获取组件
    }


    private void Update()
    {
        //从Player上获取当前武器的当前子弹数量
        int bullet = Player.Instance.currentWeapon.CurrentBulletNum;
        //判断子弹数量是否小于10，并复制子弹数量string
        if (bullet < 10) bulletNumStr = "0" + bullet;
        else bulletNumStr = bullet.ToString();
        //从Player上获取当前武器的当前弹夹数量
        int magazine = Player.Instance.currentWeapon.CurrentMagazineNum;
        //判断弹夹数量是否小于10，并复制弹夹数量string
        if (magazine < 10) magazineNumStr = "0" + magazine;
        else magazineNumStr = magazine.ToString();

        //更新ui内容显示
        bulletNumText.text = "子弹:" + bulletNumStr;
        magazineNumText.text = "弹夹:" + magazineNumStr;

        //判断是单发还是连发模式
        if (Player.Instance.currentWeapon.IsSingleFire) fireModeStr = "单发";
        else fireModeStr = "连发";

        fireModeText.text = "发射模式：" + fireModeStr;
    }
}