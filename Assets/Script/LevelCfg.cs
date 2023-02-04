using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelCfg", menuName = "ScriptableObjects/LevelCfg", order = 1)]
public class LevelCfg : ScriptableObject
{
    public float rotationalSpeed;
    public int excitationRate;  //ÿ�뼸��
    public float excitationDuration;  //�������ʱ��
    public float raySpeed; 

    public float triggerMsgInterval;
}