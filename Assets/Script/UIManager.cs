using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager GetInstance
    {
        get
        {
            return instance;
        }
    }


    public GameObject WeChatMassage;
    public GameObject DialogueLeft;
    public GameObject DialogueRight;

    public FloatingText floatingTextPrefab;
    public Transform floatingTextParent;

    public GameObject SpanPoint_WeChat;

    //public Button TestButton;
    //public Button TestButton2;
    //public Button TestButton3;

    float DelayClose_WeChat = 2.5f;

    [SerializeField] private Animation leftHandAnim;
    [SerializeField] private Animation rightHandAnim;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject eventPanel;
    [SerializeField] private GameObject follicles;
    [SerializeField] private GameObject baomuImgList;
    [SerializeField] private GameObject losePanel;

    public float timer = 60;
    private bool isEnd = false;
    public int needScore = 0;

    public void FloatingText(string msg)
    {
        FloatingText floatingText = Instantiate(floatingTextPrefab, floatingTextParent);
        floatingText.SetText(msg);
    }
    private void Awake()
    {
        instance = this;
    }
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
        if (isEnd)
        {
            return;
        }

        int timer1 = (int)timer;
        timeText.text = timer1.ToString();
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            isEnd = true;
            LevelManager.GetInstance.isEnd = true;

            if (GameManager.GetInstance.GetLevelScore() < needScore)
            {
                losePanel.SetActive(true);
                return;
            }

            follicles.SetActive(false);
            shopPanel.SetActive(true);
        }

        scoreText.text = GameManager.GetInstance.GetLevelScore().ToString();

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    GameManager.GetInstance.SetLevelScore(GameManager.GetInstance.GetLevelScore() + 1);
        //}
    }

    public void OpenEvnetPanel()
    {
        eventPanel.SetActive(true);
    }

    // ????????
    public void PushWeChat(string content)
    {
        GameObject obj = GameObject.Instantiate(this.WeChatMassage, this.SpanPoint_WeChat.transform);
        obj.transform.DOMoveY(456, 0.4f);
        
        obj.GetComponent<wechat>().name.text = "????";
        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopWeChat(obj));
    }

    // ????????????
    IEnumerator  PopWeChat(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOMoveY(656, 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    // ????????????
    public void PushDialogueLeft(string content)
    {
        GameObject obj = GameObject.Instantiate(this.DialogueLeft, this.SpanPoint_WeChat.transform);
        obj.transform.DOScale(new Vector3(1, 1, 1), 0.1f);

        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopDialogLeft(obj));
    }

    // ????????????????
    IEnumerator PopDialogLeft(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    // ????????????
    public void PushDialogueRight(string content)
    {
        GameObject obj = GameObject.Instantiate(this.DialogueRight, this.SpanPoint_WeChat.transform);
        obj.transform.DOScale(new Vector3(1, 1, 1), 0.2f);

        obj.GetComponent<wechat>().content.text = content;

        StartCoroutine(PopDialogRight(obj));
    }

    // ????????????????
    IEnumerator PopDialogRight(GameObject obj)
    {
        yield return new WaitForSeconds(DelayClose_WeChat);

        obj.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        yield return new WaitForSeconds(DelayClose_WeChat);

        Destroy(obj);
    }

    public void PerformLeftHandAnim()
    {
        leftHandAnim.Play();
    }

    public void PerformRightHandAnim()
    {
        rightHandAnim.Play();
    }

    public void PerformBaomuEffect()
    {
        if (!baomuImgList)
        {
            return;
        }
        foreach (Transform child in baomuImgList.transform)
        {
            if(child && child.GetComponent<Image>().enabled == false)
            {
                child.GetComponent<Image>().enabled = true;
                break;
            }
        }
    }
}
