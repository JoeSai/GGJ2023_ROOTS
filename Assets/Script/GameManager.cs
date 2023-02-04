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

    string ShopScore = "ShopScore";
    //string LevelScore = "LevelScore";
    string Item_Bawang = "Bawang";
    string Item_Shengfaji = "Tianlingling";
    string Item_Minuo = "Minuo";
    string Item_Feinaxiong = "feinanxiong";

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
        int ret = PlayerPrefs.GetInt(ShopScore, 0);
        return ret;
    }
    // д�빺�����
    public void SetShopScore(int shopScore)
    {
        if(PlayerPrefs.HasKey(ShopScore))
        {
            PlayerPrefs.SetInt(ShopScore, shopScore);
        }
        else
        {
            Debug.Log(ShopScore + "���ݲ�����");
        }
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
        int ret = PlayerPrefs.GetInt(Item_Bawang, 0);
        return ret;
    }
    // д�����������
    public void SetBawangCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Bawang))
        {
            PlayerPrefs.SetInt(Item_Bawang, levelScore);
        }
        else
        {
            Debug.Log(Item_Bawang + "���ݲ�����");
        }
    }

    // �õ�������������
    public int GetShengfaji()
    {
        int ret = PlayerPrefs.GetInt(Item_Shengfaji, 0);
        return ret;
    }
    // д��������������
    public void SetShengfajiCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Shengfaji))
        {
            PlayerPrefs.SetInt(Item_Shengfaji, levelScore);
        }
        else
        {
            Debug.Log(Item_Shengfaji + "���ݲ�����");
        }
    }

    // �õ���ŵ�ض���������
    public int GetMinuo()
    {
        int ret = PlayerPrefs.GetInt(Item_Minuo, 0);
        return ret;
    }
    // д����ŵ�ض���������
    public void SetMinuoCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Minuo))
        {
            PlayerPrefs.SetInt(Item_Minuo, levelScore);
        }
        else
        {
            Debug.Log(Item_Minuo + "���ݲ�����");
        }
    }

    // �õ������۰�Ƭ������
    public int GetFeinaxiong()
    {
        int ret = PlayerPrefs.GetInt(Item_Feinaxiong, 0);
        return ret;
    }
    // д������۰�Ƭ������
    public void SetFeinaxiongCount(int levelScore)
    {
        if (PlayerPrefs.HasKey(Item_Feinaxiong))
        {
            PlayerPrefs.SetInt(Item_Feinaxiong, levelScore);
        }
        else
        {
            Debug.Log(Item_Feinaxiong + "���ݲ�����");
        }
    }
}
