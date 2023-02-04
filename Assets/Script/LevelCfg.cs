using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelCfg", menuName = "ScriptableObjects/LevelCfg", order = 1)]
public class LevelCfg : ScriptableObject
{
    public float rotationalSpeed;
    public int excitationRate;  //每秒几个
    public float excitationDuration;  //激活持续时间
    public float raySpeed; 

    public float triggerMsgInterval;
}