using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject Hand;

    public Button Item1;
    public Button Item2;
    public Button Item3;
    public Button Item4;

    int ItemPrice = 10;

    // Start is called before the first frame update
    void Start()
    {
        Item1.onClick.AddListener(BuyItem1);
        Item2.onClick.AddListener(BuyItem2);
        Item3.onClick.AddListener(BuyItem3);
        Item4.onClick.AddListener(BuyItem4);
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
        //print(Input.mousePosition);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseScreenPosition.z);
        //// ���ò����ֵ�λ��
        Hand.transform.position = mouseWorldPosition;
    }

    // �ж�Ǯ�Ƿ��㹻�������
    public bool IsCoinEnough()
    {
        int currentCoin = GameManager.GetInstance.GetShopScore();

        if(currentCoin >= ItemPrice)
        {
            return true;
        }
        else
        {
            Debug.Log("����");

            return false;
        }
    }

    // ���߹���
    // ��������ϴ��ˮ
    public void BuyItem1()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetBawangCount();
            GameManager.GetInstance.SetBawangCount(currentCount + 1);
        }
    }
    // ������
    public void BuyItem2()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetShengfaji();
            GameManager.GetInstance.SetShengfajiCount(currentCount + 1);
        }
    }
    // ��ŵ�ض���
    public void BuyItem3()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetMinuo();
            GameManager.GetInstance.SetMinuoCount(currentCount + 1);
        }
    }
    // �����۰�Ƭ
    public void BuyItem4()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetFeinaxiong();
            GameManager.GetInstance.SetFeinaxiongCount(currentCount + 1);
        }
    }

    public void OnClickNext()
    {
        this.gameObject.SetActive(false);
        UIManager.GetInstance.OpenEvnetPanel();
    }
}
