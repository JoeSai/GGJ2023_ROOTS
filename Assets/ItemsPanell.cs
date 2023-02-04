using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanell : MonoBehaviour
{
    [SerializeField] private Text bwCount;
    [SerializeField] private Text sfjCount;
    [SerializeField] private Text mndCount;
    [SerializeField] private Text fnxCount;
    // Start is called before the first frame update
    void Start()
    {
        bwCount.text = GameManager.GetInstance.GetBawangCount().ToString();
        sfjCount.text = GameManager.GetInstance.GetShengfaji().ToString();
        mndCount.text = GameManager.GetInstance.GetMinuo().ToString();
        fnxCount.text = GameManager.GetInstance.GetFeinaxiong().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBW()
    {
        int count = GameManager.GetInstance.GetBawangCount();
        if (count > 0)
        {
            LevelManager.GetInstance.TurnOnDebuffResistance();
            GameManager.GetInstance.SetBawangCount(count - 1);
        }
    }
    public void OnClickSfj()
    {
        int count = GameManager.GetInstance.GetShengfaji();
        if (count > 0)
        {
            LevelManager.GetInstance.TurnOnExcitationRateUp();
            GameManager.GetInstance.SetShengfajiCount(count - 1);
        }
    }
    public void OnClickMnd()
    {
        int count = GameManager.GetInstance.GetMinuo();
        if (count > 0)
        {
            LevelManager.GetInstance.TurnOnRaySpeedUp();
            GameManager.GetInstance.SetMinuoCount(count - 1);
        }
    }
    public void OnClickFnx()
    {
        int count = GameManager.GetInstance.GetFeinaxiong();
        if (count > 0)
        {
            LevelManager.GetInstance.TurnOnRotationalSpeedDown();
            GameManager.GetInstance.SetFeinaxiongCount(count - 1);
        }
    }
}
