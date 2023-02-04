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

    // �õ��������
    public int GetShopScore()
    {
        return shopScore;
    }
    // д�빺�����
    public void SetShopScore(int shopScore)
    {
        this.shopScore = shopScore;
    }

    // �õ��ؿ��÷�
    public int GetLevelScore()
    {
        return levelScore;
        //int ret = PlayerPrefs.GetInt(LevelScore, 0);
        //return ret;
    }
    // д��ؿ�����
    public void SetLevelScore(int levelScore)
    {
        this.levelScore = levelScore;
        if(this.levelScore < 0)
        {
            this.levelScore = 0;
        }

    }

    // �õ�����������
    public int GetBawangCount()
    {
        return bwCount;

    }
    // д�����������
    public void SetBawangCount(int count)
    {
        bwCount = levelScore;
    }

    // �õ�������������
    public int GetShengfaji()
    {
        return sfjCount;
    }
    // д��������������
    public void SetShengfajiCount(int count)
    {
         sfjCount = count;
    }

    // �õ���ŵ�ض���������
    public int GetMinuo()
    {
        return mnCount;
    }
    // д����ŵ�ض���������
    public void SetMinuoCount(int count)
    {
        mnCount = count;
    }

    // �õ������۰�Ƭ������
    public int GetFeinaxiong()
    {
        return fnxCount;
    }
    // д������۰�Ƭ������
    public void SetFeinaxiongCount(int count)
    {
        fnxCount = count;
    }
}
