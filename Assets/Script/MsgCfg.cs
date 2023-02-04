using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MsgParam
{
    public int type;
    public string text;
}

[CreateAssetMenu(fileName = "New MsgCfg", menuName = "ScriptableObjects/MsgCfg", order = 1)]
public class MsgCfg : ScriptableObject
{

    [System.Serializable]
    public class MsgData
    {
        public List<string> msgList;
        public float probability;
        public int buffType;
    }

    public MsgData bossMsgData;
    public MsgData artserMsgData;
    public MsgData designerMsgData;

    public MsgParam GetRandomMsg()
    {
        float totalProbability = bossMsgData.probability + artserMsgData.probability + designerMsgData.probability;
        float randomValue = Random.Range(0, totalProbability);

        int t;
        List<string> tempMsgList;
        if (randomValue <= bossMsgData.probability)
        {
            tempMsgList = bossMsgData.msgList;
            t = bossMsgData.buffType;
        }
        else if(randomValue <= bossMsgData.probability + artserMsgData.probability){
            tempMsgList = artserMsgData.msgList;
            t = artserMsgData.buffType;
        }
        else
        {
            tempMsgList = designerMsgData.msgList;
            t = designerMsgData.buffType;
        }

        int randomIndex = Random.Range(0, tempMsgList.Count);

        MsgParam param;

        param.type = t;
        param.text = tempMsgList[randomIndex];

        return param;

    }
}