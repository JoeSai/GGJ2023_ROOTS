using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuffEvent
{
    public string bufferName;
    public BuffType buffTpye;
    public int count; // ����
    public int arena; // ����
    public int duration; // ʱ��
}

public enum BuffType
{
    FollicleObstructed,
    L_RegionalAlopecia,
    R_RegionalAlopecia,
    RandomAlopecia,
}

[CreateAssetMenu(fileName = "New BuffCfg", menuName = "ScriptableObjects/BuffCfg", order = 1)]
public class BuffCfg : ScriptableObject
{
    public List<BuffEvent> events;
}