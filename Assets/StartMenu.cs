using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartMenu : MonoBehaviour
{
    public Button BtnStart;

    public Image DesPanel;

    public Text DesText;

    public string fullText = "起初，没有人在意这场灾难\n这不过是一次通宵\n一次应酬\n一个需求的实现\n一家公司的崛起\n直到这常灾难和每个人都息息相关";

    // Start is called before the first frame update
    void Start()
    {
        BtnStart.onClick.AddListener(Intro);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Intro()
    {
        DesPanel.DOFade(1, 2.0f).OnComplete(() =>
        {
            Tweener TypeText = DesText.DOText(fullText, 6.0f);
            TypeText.SetEase(Ease.Linear);
            TypeText.OnComplete(() =>
            {
                StartGame();
            });
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
