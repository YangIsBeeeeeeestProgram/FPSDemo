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
                print("1111");
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
                Player.Instance.currentWeapon.Fire();
        }
    }
}