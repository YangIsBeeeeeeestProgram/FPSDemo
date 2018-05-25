using UnityEngine;

public class InputManager: MonoBehaviour {

    private void Update()
    {
        OnKeyboardControl();
    }



    void OnKeyboardControl()
    {
        //判断玩家当前使用的武器是不是单发模式
        if (Player.Instance.currentWeapon.IsSingleFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Player.Instance.currentWeapon.Fire();
                Player.Instance.DetectionFire();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Player.Instance.currentWeapon.Fire();
                Player.Instance.DetectionFire();
            }
        }
        //更换弹夹
        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.Instance.currentWeapon.Reload();
        }

        //更换发射模式
        if (Input.GetKeyDown(KeyCode.B))
        {
            Player.Instance.currentWeapon.ChangeFireMode();
        }
    }
}