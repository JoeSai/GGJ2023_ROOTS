using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager GetInstance
    {
        get
        {
            if(instance == null)
            {
                instance = Activator.CreateInstance<GameManager>();
            }
            return instance;
        }
    }

    string ShopScore = "ShopScore";
    string LevelScore = "LevelScore";
    string Item_Bawang = "Bawang";
    string Item_Tianlingling = "Tianlingling";
    string Item_minuo = "Minuo";
    string Item_feinaxiong = "feinanxiong";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 拿到购物积分
    public void GetShopScore()
    {
        PlayerPrefs.GetInt(ShopScore, 0);
    }
    // 写入购物积分
    public void SetShopScore(int shopScore)
    {
        if(PlayerPrefs.HasKey(ShopScore))
        {
            PlayerPrefs.SetInt(ShopScore, shopScore);
        }
        else
        {
            Debug.Log(ShopScore + "数据不存在");
        }
    }

    // 拿到关卡得分
    public void GetLevelScore()
    {
        PlayerPrefs.GetInt(LevelScore, 0);
    }
    // 写入关卡积分
    public void SetLevelScore(int levelScore)
    {
        if (PlayerPrefs.HasKey(LevelScore))
        {
            PlayerPrefs.SetInt(LevelScore, levelScore);
        }
        else
        {
            Debug.Log(LevelScore + "数据不存在");
        }
    }

    // 拿到霸王的数量
    public void GetBawangCount()
    {
        PlayerPrefs.GetInt(Item_Bawang, 0);
    }
    // 写入霸王的数量
    public void SetBawangCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Bawang))
        {
            PlayerPrefs.SetInt(Item_Bawang, levelScore);
        }
        else
        {
            Debug.Log(Item_Bawang + "数据不存在");
        }
    }
}
