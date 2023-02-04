using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public enum SleepState
{
    Normal,
    Hangover,
    StayUpLate,
    SleepEarly,
    Happy,
}


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager GetInstance
    {
        get
        {
            //if(instance == null)
            //{
            //    instance = Activator.CreateInstance<GameManager>();
            //}
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private SleepState sleepState = SleepState.Normal;

    public void SetSleepState(SleepState state)
    {
        sleepState = state;
    }

    public SleepState GetSleepState()
    {
        return sleepState;
    }

    int shopScore;
    int bwCount;
    int sfjCount;
    int mnCount;
    int fnxCount;


    int levelScore = 0;

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
        return shopScore;
    }
    // 写入购物积分
    public void SetShopScore(int shopScore)
    {
        this.shopScore = shopScore;
    }

    // 拿到关卡得分
    public int GetLevelScore()
    {
        return levelScore;
        //int ret = PlayerPrefs.GetInt(LevelScore, 0);
        //return ret;
    }
    // 写入关卡积分
    public void SetLevelScore(int levelScore)
    {
        this.levelScore = levelScore;
        if(this.levelScore < 0)
        {
            this.levelScore = 0;
        }

    }

    // 拿到霸王的数量
    public int GetBawangCount()
    {
        return bwCount;

    }
    // 写入霸王的数量
    public void SetBawangCount(int count)
    {
        bwCount = levelScore;
    }

    // 拿到生发剂的数量
    public int GetShengfaji()
    {
        return sfjCount;
    }
    // 写入生发剂的数量
    public void SetShengfajiCount(int count)
    {
         sfjCount = count;
    }

    // 拿到米诺地尔酊的数量
    public int GetMinuo()
    {
        return mnCount;
    }
    // 写入米诺地尔酊的数量
    public void SetMinuoCount(int count)
    {
        mnCount = count;
    }

    // 拿到非那雄氨片的数量
    public int GetFeinaxiong()
    {
        return fnxCount;
    }
    // 写入非那雄胺片的数量
    public void SetFeinaxiongCount(int count)
    {
        fnxCount = count;
    }
}
