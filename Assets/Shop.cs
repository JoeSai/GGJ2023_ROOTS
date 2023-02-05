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

    public GameObject Sale1;
    public GameObject Sale2;
    public GameObject Sale3;
    public GameObject Sale4;

    public Text Money;

    int ItemPrice = 10;

    // Start is called before the first frame update
    void Start()
    {
        Item1.onClick.AddListener(BuyItem1);
        Item2.onClick.AddListener(BuyItem2);
        Item3.onClick.AddListener(BuyItem3);
        Item4.onClick.AddListener(BuyItem4);

        GameManager.GetInstance.SetShopScore(GameManager.GetInstance.GetShopScore() + 20);

        Money.text = "￥" + GameManager.GetInstance.GetShopScore();
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
        //print(Input.mousePosition);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseScreenPosition.z);
        //// 设置操作手的位置
        Hand.transform.position = mouseWorldPosition;
    }

    // 判断钱是否足够购买道具
    public bool IsCoinEnough()
    {
        int currentCoin = GameManager.GetInstance.GetShopScore();

        if(currentCoin >= ItemPrice)
        {
            GameManager.GetInstance.SetShopScore(GameManager.GetInstance.GetShopScore() - 10);
            UIManager.GetInstance.FloatingText("已下单");
            Money.text = "￥" + GameManager.GetInstance.GetShopScore();

            AudioManager.instance.PlaySoundEffectByName("Shop_Buy");
            return true;
        }
        else
        {
            UIManager.GetInstance.FloatingText("余额不足");
            return false;
        }
    }

    // 道具购买
    // 霸王防脱洗发水
    public void BuyItem1()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetBawangCount();
            GameManager.GetInstance.SetBawangCount(currentCount + 1);

            print(GameManager.GetInstance.GetBawangCount());

            Sale1.SetActive(true);
        }
    }
    // 生发剂
    public void BuyItem2()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetShengfaji();
            GameManager.GetInstance.SetShengfajiCount(currentCount + 1);

            Sale2.SetActive(true);
        }
    }
    // 米诺地尔酊
    public void BuyItem3()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetMinuo();
            GameManager.GetInstance.SetMinuoCount(currentCount + 1);

            Sale3.SetActive(true);
        }
    }
    // 非那雄氨片
    public void BuyItem4()
    {
        if (IsCoinEnough())
        {
            int currentCount = GameManager.GetInstance.GetFeinaxiong();
            GameManager.GetInstance.SetFeinaxiongCount(currentCount + 1);

            Sale4.SetActive(true);
        }
    }

    public void OnClickNext()
    {
        this.gameObject.SetActive(false);
        UIManager.GetInstance.OpenEvnetPanel();
    }
}
