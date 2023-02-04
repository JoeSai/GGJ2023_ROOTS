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
    string Item_Shengfaji = "Tianlingling";
    string Item_Minuo = "Minuo";
    string Item_Feinaxiong = "feinanxiong";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 拿到购物积分
    public int GetShopScore()
    {
        int ret = PlayerPrefs.GetInt(ShopScore, 0);
        return ret;
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
    public int GetLevelScore()
    {
        int ret = PlayerPrefs.GetInt(LevelScore, 0);
        return ret;
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
    public int GetBawangCount()
    {
        int ret = PlayerPrefs.GetInt(Item_Bawang, 0);
        return ret;
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

    // 拿到生发剂的数量
    public int GetShengfaji()
    {
        int ret = PlayerPrefs.GetInt(Item_Shengfaji, 0);
        return ret;
    }
    // 写入生发剂的数量
    public void SetShengfajiCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Shengfaji))
        {
            PlayerPrefs.SetInt(Item_Shengfaji, levelScore);
        }
        else
        {
            Debug.Log(Item_Shengfaji + "数据不存在");
        }
    }

    // 拿到米诺地尔酊的数量
    public int GetMinuo()
    {
        int ret = PlayerPrefs.GetInt(Item_Minuo, 0);
        return ret;
    }
    // 写入米诺地尔酊的数量
    public void SetMinuoCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Minuo))
        {
            PlayerPrefs.SetInt(Item_Minuo, levelScore);
        }
        else
        {
            Debug.Log(Item_Minuo + "数据不存在");
        }
    }

    // 拿到非那雄氨片的数量
    public int GetFeinaxiong()
    {
        int ret = PlayerPrefs.GetInt(Item_Feinaxiong, 0);
        return ret;
    }
    // 写入非那雄胺片的数量
    public void SetFeinaxiongCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Feinaxiong))
        {
            PlayerPrefs.SetInt(Item_Feinaxiong, levelScore);
        }
        else
        {
            Debug.Log(Item_Feinaxiong + "数据不存在");
        }
    }
}
