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

    // �õ��������
    public void GetShopScore()
    {
        PlayerPrefs.GetInt(ShopScore, 0);
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
    public void GetLevelScore()
    {
        PlayerPrefs.GetInt(LevelScore, 0);
    }
    // д��ؿ�����
    public void SetLevelScore(int levelScore)
    {
        if (PlayerPrefs.HasKey(LevelScore))
        {
            PlayerPrefs.SetInt(LevelScore, levelScore);
        }
        else
        {
            Debug.Log(LevelScore + "���ݲ�����");
        }
    }

    // �õ�����������
    public void GetBawangCount()
    {
        PlayerPrefs.GetInt(Item_Bawang, 0);
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
}
