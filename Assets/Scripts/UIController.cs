using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour {

    Text BulletNumText; //子弹数量ui
    Text MagazineNumText;//弹夹数量ui

    string BulletNumStr = string.Empty; //当前子弹数量string
    string MagazineNumStr = string.Empty;//当前弹夹数量string
    private void Awake()
    {
        BulletNumText = this.transform.Find("BulletNumText").GetComponent<Text>(); //从子物体中找到ui对象并获取组件
        MagazineNumText = this.transform.Find("MagazineNumText").GetComponent<Text>();//从子物体中找到ui对象并获取组件
    }


    private void Update()
    {
        //从Player上获取当前武器的当前子弹数量
        int bullet = Player.Instance.currentWeapon.CurrentBulletNum;
        //判断子弹数量是否小于10，并复制子弹数量string
        if (bullet < 10) BulletNumStr = "0" + bullet;
        else BulletNumStr = bullet.ToString();
        //从Player上获取当前武器的当前弹夹数量
        int magazine = Player.Instance.currentWeapon.CurrentMagazineNum;
        //判断弹夹数量是否小于10，并复制弹夹数量string
        if (magazine < 10) MagazineNumStr = "0" + magazine;
        else MagazineNumStr = magazine.ToString();

        //更新ui内容显示
        BulletNumText.text = string.Format("子弹:" + BulletNumStr);
        MagazineNumText.text = string.Format("弹夹:" + MagazineNumStr);
    }
}