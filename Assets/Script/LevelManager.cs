using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager GetInstance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField] public List<Hair> leftHairList = new List<Hair>();
    [SerializeField] public List<Hair> rightHairList = new List<Hair>();

    [SerializeField] List<Follicle> follicleList;

    [SerializeField] UIManager uimanager;

    [SerializeField] private LevelCfg levelCfg;
    [SerializeField] private MsgCfg msgCfg;
    [SerializeField] private BuffCfg buffCfg;
    //[SerializeField] private LevelCfg levelCfg2;

    [SerializeField] RootsController rootsController;


    [SerializeField] private float rotationalSpeed; //转动速度
    [SerializeField] private float raySpeed; //射线速度

    [SerializeField] private int excitationRate; //毛囊激活速率
    [SerializeField] private float excitationDuration; //毛囊激活时间


    [SerializeField] private float triggerMsgInterval;

    private float triggerMsgTimer;

    [SerializeField] private Transform follicleLeftParent;
    [SerializeField] private Transform follicleRightParent;
    [SerializeField] private Transform follicleCenterParent;

    private float excitationInterval = 1f; // 毛囊激活间隔
    private float excitationTimer = 0f;

    private bool debuffResistanceIsOn = false; //霸王防脱
    private bool excitationRateUpIsOn = false; //天灵灵生发剂
    private bool raySpeedUpIsOn = false; //米诺地尔酊
    private bool rotationalSpeedDownIsOn = false; //非那雄胺片

    public bool isEnd = false;

    public void TurnOnDebuffResistance() { 
    
        if(!debuffResistanceIsOn)
        {
            debuffResistanceIsOn = true;
            uimanager.FloatingText("减少所有减益效果的影响");
        }

        //uimanager.
    }
    public void TurnOnExcitationRateUp()
    {
        if (!excitationRateUpIsOn)
        {
            excitationRateUpIsOn = true;
            excitationRate += 1;
        }

        //uimanager.
    }
    public void TurnOnRaySpeedUp()
    {
        if(!raySpeedUpIsOn)
        {
            raySpeedUpIsOn = true;

            raySpeed += 2;
            rootsController.SetBaseValue(rotationalSpeed, raySpeed);
            //uimanager.
        }

    }
    public void TurnOnRotationalSpeedDown()
    {
        if (!rotationalSpeedDownIsOn)
        {
            rotationalSpeedDownIsOn = true;
            rotationalSpeed -= 2;
            rootsController.SetBaseValue(rotationalSpeed, raySpeed);
        }
        //uimanager.
    }

    private void Awake()
    {
        instance = this;
        InitCfg();

        InitController();
        InitFollicleList();
        /*InitMsgList*/
    }

    private void Start()
    {
        HandleSleepState();
    }

    private void HandleSleepState()
    {
        SleepState sleepState = GameManager.GetInstance.GetSleepState();
        List<Follicle> hideList = new List<Follicle>();
        switch (sleepState)
        {
            case SleepState.Normal:
                break;
            case SleepState.Hangover:
                for (int i = 0; i < follicleList.Count; i++)
                {
                    if(i % 2 == 0)
                    {
                        hideList.Add(follicleList[i]);
                    }
                }

                StartCoroutine(HideFollicle(hideList));
                break;
            case SleepState.StayUpLate:

                //for (int i = 0; i < follicleList.Count; i++)
                //{
                //    if (i % 3 == 0)
                //    {
                //        hideList.Add(follicleList[i]);
                //    }
                //}
                rotationalSpeed += 1;

                StartCoroutine(HideFollicle(hideList));
                break;
            case SleepState.SleepEarly:
                excitationRate += 1;
                break;
            case SleepState.Happy:
                raySpeed += 2;
                break;
            default:
                break;
        }
    }

    private IEnumerator HideFollicle(List<Follicle> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void InitCfg()
    {
        rotationalSpeed = levelCfg.rotationalSpeed;
        excitationRate = levelCfg.excitationRate;
        excitationDuration = levelCfg.excitationDuration;
        triggerMsgInterval = levelCfg.triggerMsgInterval;
        raySpeed = levelCfg.raySpeed;
    }

    private void InitFollicleList()
    {
        follicleList = new List<Follicle>();

        foreach (var follicle in follicleLeftParent.GetComponentsInChildren<Follicle>())
        {
            follicleList.Add(follicle);

            follicle.Init(excitationDuration, true);
        }

        foreach (var follicle in follicleRightParent.GetComponentsInChildren<Follicle>())
        {
            follicleList.Add(follicle);

            follicle.Init(excitationDuration, false);
        }

        foreach (var follicle in follicleCenterParent.GetComponentsInChildren<Follicle>())
        {
            follicleList.Add(follicle);

            int radomNum = Random.Range(0, 2);

            if(radomNum == 0)
            {
                follicle.Init(excitationDuration, false);
            }
            else
            {
                follicle.Init(excitationDuration, true);
            }
        }
    }

    private void InitController()
    {
        rootsController.SetBaseValue(rotationalSpeed, raySpeed);
    }


    private void Update()
    {
        if (isEnd)
        {
            return;
        }
        ActiveFollicle();
        TriggerMsg();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TurnOnDebuffResistance();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TurnOnExcitationRateUp();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TurnOnRaySpeedUp();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TurnOnRotationalSpeedDown();
        }
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

            HandleMsgByType(buffType, msgString);
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
        int count = e.count;

        if (debuffResistanceIsOn)
        {
            count = count - 1;
        }

        int duration = e.duration;
        List<Hair> list;
        switch (e.buffTpye)
        {
    
            case BuffType.FollicleObstructed:
                List<Follicle> selectedList = new List<Follicle>();

                var deadFollicles = follicleList
                .Where(follicle => follicle.GetState() != FollicleState.Obstructed)
                .ToList();


                System.Random random = new System.Random();
                int selectCount = 0;
                while (selectCount < count && deadFollicles.Count > 0)
                {
                    int index = random.Next(deadFollicles.Count);
                    selectedList.Add(deadFollicles[index]);
                    deadFollicles.RemoveAt(index);
                    selectCount++;
                }

                foreach (var follicle in selectedList)
                {
                    follicle.SetObstructedDuration(duration);
                    follicle.SetState(FollicleState.Obstructed);
                }

                break;

            case BuffType.RandomAlopecia:
                break;

            case BuffType.L_RegionalAlopecia:
                //print("l tuofa");
                list = GetRandomElements(leftHairList, count);
                foreach (var hair in list)
                {
                    leftHairList.Remove(hair);
                    hair.SetHairDown();
                    GameManager.GetInstance.SetLevelScore(GameManager.GetInstance.GetLevelScore() - 1);
                }
                uimanager.PerformLeftHandAnim();
                //AudioManager.instance.PlaySoundEffectByName("Hair_Grab");
                break;

            case BuffType.R_RegionalAlopecia:
                list = GetRandomElements(rightHairList, count);
                foreach (var hair in list)
                {
                    rightHairList.Remove(hair);
                    hair.SetHairDown();
                    GameManager.GetInstance.SetLevelScore(GameManager.GetInstance.GetLevelScore() - 1);
                }
                //print("r tuofa");
                uimanager.PerformRightHandAnim();
                //AudioManager.instance.PlaySoundEffectByName("Hair_Grab");
                break;

        }
    }

    private void HandleMsgByType(int type, string msgString)
    {
        switch (type)
        {
            case 0:
                uimanager.PushWeChat(msgString);
                uimanager.PerformBaomuEffect();
                AudioManager.instance.PlaySoundEffectByName("Message_Wechat");
                break;
            case 1:
                uimanager.PushDialogueLeft(msgString);
                uimanager.PerformBaomuEffect();
                AudioManager.instance.PlaySoundEffectByName("Message_Notfication");
                break;
            case 2:
                uimanager.PushDialogueRight(msgString);
                uimanager.PerformBaomuEffect();
                AudioManager.instance.PlaySoundEffectByName("Message_Notfication");
                break;
        }
    }

    public static List<T> GetRandomElements<T>(List<T> list, int n)
    {
        List<T> selectedElements = new List<T>();
        System.Random random = new System.Random();
        int count = 0;
        while (count < n && list.Count > 0)
        {
            int index = random.Next(list.Count);
            selectedElements.Add(list[index]);
            list.RemoveAt(index);
            count++;
        }
        return selectedElements;
    }


    public void Hangover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.GetInstance.SetSleepState(SleepState.Hangover);
    }
    public void StayUpLate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.GetInstance.SetSleepState(SleepState.StayUpLate);
    }
    public void SleepEarly()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.GetInstance.SetSleepState(SleepState.SleepEarly);
    }
    public void Happy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.GetInstance.SetSleepState(SleepState.Happy);
    }

}

