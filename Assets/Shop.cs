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

    // �����ָ���
    public void HandFollow()
    {
        // ��ȡ������Ļ����
        Vector3 mouseScreenPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        mouseScreenPosition.z = 0;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseScreenPosition.z);
        // ���ò����ֵ�λ��
        Hand.transform.position = mousePosition;
    }

    // ���߹���
    public void BuyItem()
    {

    }
}
