using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandFollow();
    }

    // 操作手跟随
    public void HandFollow()
    {
        // 获取鼠标的屏幕坐标
        Vector3 mouseScreenPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        mouseScreenPosition.z = 0;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseScreenPosition.z);
        // 设置操作手的位置
        Hand.transform.position = mousePosition;
    }

    // 道具购买
    public void BuyItem()
    {

    }
}
