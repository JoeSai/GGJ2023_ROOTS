using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject WeChatMassage;
    public GameObject DialogueLeft;
    public GameObject DialogueRight;

    public GameObject SpanPoint_WeChat;

    //public Button TestButton;
    //public Button TestButton2;
    //public Button TestButton3;

    float DelayClose_WeChat = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //this.TestButton.onClick.AddListener(PushWeChat);
        //this.TestButton2.onClick.AddListener(PushDialogueLeft);
        //this.TestButton3.onClick.AddListener(PushDialogueRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 微信弹框
    public void PushWeChat(string content)
    {
        GameObject obj = GameObject.Instantiate(this.WeChatMassage, this.SpanPoint_WeChat.transform);
        obj.transform.DOMoveY(456, 0.4f);
        
        obj.GetComponent<wechat>().name.text = "老板";
        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopWeChat(obj));
    }

    // 微信弹框消失
    IEnumerator  PopWeChat(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOMoveY(656, 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    // 左侧气泡弹出
    public void PushDialogueLeft(string content)
    {
        GameObject obj = GameObject.Instantiate(this.DialogueLeft, this.SpanPoint_WeChat.transform);
        obj.transform.DOScale(new Vector3(1, 1, 1), 0.1f);

        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopDialogLeft(obj));
    }

    // 左侧对话气泡消失
    IEnumerator PopDialogLeft(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    // 右侧气泡弹出
    public void PushDialogueRight(string content)
    {
        GameObject obj = GameObject.Instantiate(this.DialogueRight, this.SpanPoint_WeChat.transform);
        obj.transform.DOScale(new Vector3(1, 1, 1), 0.2f);

        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopDialogRight(obj));
    }

    // 右侧对话气泡消失
    IEnumerator PopDialogRight(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }
}
