using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject WeChatMassage;

    public GameObject SpanPoint_WeChat;

    public Button TestButton;

    float DelayClose_WeChat = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.TestButton.onClick.AddListener(PushWeChat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 微信弹框
    public void PushWeChat()
    {
        GameObject obj = GameObject.Instantiate(this.WeChatMassage, this.SpanPoint_WeChat.transform);
        obj.transform.DOMoveY(471, 0.4f);

        StartCoroutine(PopWeChat(obj));
    }

    // 微信弹框消失
    IEnumerator  PopWeChat(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOMoveY(671, 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    // 气泡弹出
    public void PushDialogue()
    {

    }

    // 对话气泡消失

}
