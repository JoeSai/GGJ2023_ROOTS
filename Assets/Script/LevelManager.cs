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
    //[SerializeField] private LevelCfg levelCfg2;

    [SerializeField] RootsController rootsController;
    [SerializeField] List<Follicle> follicleList;  

    [SerializeField] private float rotationalSpeed; //转动速度
    [SerializeField] private int excitationRate; //毛囊激活速率
    [SerializeField] private float excitationDuration; //毛囊激活时间

    [SerializeField] private Transform follicleParent;

    private void Awake()
    {
        InitController();
        InitFollicleList();
    }

    private void InitFollicleList()
    {
        follicleList = new List<Follicle>();

        foreach (var follicle in follicleParent.GetComponentsInChildren<Follicle>())
        {
            follicleList.Add(follicle);
        }
    }

    private void InitController()
    {
        rotationalSpeed = levelCfg.rotationalSpeed;
        excitationRate = levelCfg.excitationRate;
        excitationDuration = levelCfg.excitationDuration;

        rootsController.SetBaseValue(rotationalSpeed, excitationRate, excitationDuration);
    }

    private void Update()
    {
        ActiveFollicle();
    }

    private void ActiveFollicle()
    {
        var selectedObjects = follicleList
                    .Where(follicle => follicle.GetState() == FollicleState.Live)
                    .Take(excitationRate)
                    .ToList();

        print(selectedObjects);
    }
}

