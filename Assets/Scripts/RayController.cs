using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RayController: MonoBehaviour {


    Ray ray;//射线类实例
    public RaycastHit raycastHit;//射线碰撞信息类实例
    public bool IsCast = false;
    Vector3 origin;//射线起始点位置
    Vector3 direction;//射线方向
    int magnitude = 30;//射线长度

    LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        origin = this.transform.position;//射线起点始终为当前脚本挂在的游戏对象的世界位置
        direction = this.transform.forward;//射线发射方向始终为当前脚本所挂载的游戏对象的z轴朝向的世界位置
        ray = new Ray(origin, direction);//持续实例化射线，调用有参构造函数，参数传入为世界坐标系的起点位置和方向
        lineRenderer.SetPosition(0, origin);
        IsCast = Physics.Raycast(ray, out raycastHit, magnitude);//判断射线是否碰撞到碰撞体，out出碰撞信息，返回bool

        if (IsCast)
        {
            //在编辑器scene窗口中绘制显示射线，传入起点位置和终点位置(碰撞点的位置)以及射线颜色
            Debug.DrawLine(origin, raycastHit.point, Color.red);
            lineRenderer.SetPosition(1, raycastHit.point);
        }
        else
        {
            //在编辑器scene窗口中绘制显示射线，传入起点位置和终点位置(射线方向100长度的位置)以及射线颜色
            Debug.DrawLine(origin, ray.GetPoint(magnitude), Color.white);
            lineRenderer.SetPosition(1, ray.GetPoint(magnitude));
        }


        

    }
}