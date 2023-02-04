using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuffEvent
{
    public string bufferName;
    public BuffType buffTpye;
    public int count; // 数量
    public int arena; // 区域
    public int duration; // 时间
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