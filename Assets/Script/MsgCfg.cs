using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MsgCfg", menuName = "ScriptableObjects/MsgCfg", order = 1)]
public class MsgCfg : ScriptableObject
{
    [SerializeField] private List<string> bossMsgList;
    [SerializeField] private List<string> artserMsgList;
    [SerializeField] private List<string> designerMsgList;
}