using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] UIManager uimanager;

    [SerializeField] private LevelCfg levelCfg;
    [SerializeField] private MsgCfg msgCfg;
    [SerializeField] private BuffCfg buffCfg;
    //[SerializeField] private LevelCfg levelCfg2;

    [SerializeField] RootsController rootsController;
    [SerializeField] List<Follicle> follicleList;  

    [SerializeField] private float rotationalSpeed; //转动速度
    [SerializeField] private int excitationRate; //毛囊激活速率
    [SerializeField] private float excitationDuration; //毛囊激活时间


    [SerializeField] private float triggerMsgInterval;

    private float triggerMsgTimer;

    [SerializeField] private Transform follicleParent;

    private float excitationInterval = 1f; // 毛囊激活间隔
    private float excitationTimer = 0f;

    private void Awake()
    {
        InitCfg();

        InitController();
        InitFollicleList();
        /*InitMsgList*/
    }

    private void InitCfg()
    {
        rotationalSpeed = levelCfg.rotationalSpeed;
        excitationRate = levelCfg.excitationRate;
        excitationDuration = levelCfg.excitationDuration;
        triggerMsgInterval = levelCfg.triggerMsgInterval;
    }

    private void InitFollicleList()
    {
        follicleList = new List<Follicle>();

        foreach (var follicle in follicleParent.GetComponentsInChildren<Follicle>())
        {
            follicleList.Add(follicle);

            follicle.Init(excitationDuration);
        }
    }

    private void InitController()
    {
        rootsController.SetBaseValue(rotationalSpeed, excitationRate, excitationDuration);
    }


    private void Update()
    {
        ActiveFollicle();
        TriggerMsg();
    }

    private void TriggerMsg()
    {
        triggerMsgTimer += Time.deltaTime;
        if (triggerMsgTimer > triggerMsgInterval)
        {
            triggerMsgTimer = 0;
            MsgParam param = msgCfg.GetRandomMsg();

            int buffType = param.type;
            string msgString = param.text;

            BuffEvent buffEvent = buffCfg.events[buffType];

            HandleBuffer(buffEvent);

            //print(param.type);
            //print(param.text);
        }
    }

    private void ActiveFollicle()
    {
        if(excitationTimer > excitationInterval)
        {
            List<Follicle> selectedList = new List<Follicle>();

            var liveFollicles = follicleList
            .Where(follicle => follicle.GetState() == FollicleState.Live)
            .ToList();


            System.Random random = new System.Random();
            int count = 0;
            while (count < excitationRate && liveFollicles.Count > 0)
            {
                int index = random.Next(liveFollicles.Count);
                selectedList.Add(liveFollicles[index]);
                liveFollicles.RemoveAt(index);
                count++;
            }


            foreach (var follicle in selectedList)
            {
                follicle.SetState(FollicleState.Active);
            }

            excitationTimer = 0f;
        }
        excitationTimer += Time.deltaTime;
    }
    private void HandleBuffer(BuffEvent e){
        switch (e.buffTpye)
        {
            case BuffType.FollicleObstructed:
                break;

            case BuffType.RandomAlopecia:
                break;

            case BuffType.RegionalAlopecia:
                break;

        }
    }


}

