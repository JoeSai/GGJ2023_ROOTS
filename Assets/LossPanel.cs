using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LossPanel : MonoBehaviour
{
    [SerializeField] private Text lossText;
    [SerializeField] private Text lossText2;

    public float typingSpeed = 0.2f;
    public string fullText1 = "风萧萧兮铁铲寒";
    public string fullText2 = "壮士离职兮不复还";

    private string currentText = "";
    [SerializeField] GameObject restartBtn;

    public Image black;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PerformEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PerformEnd()
    {
        black.DOColor(new Color(1, 1, 1), 2);

        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            lossText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        lossText.text = fullText1;

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < fullText2.Length; i++)
        {
            currentText = fullText2.Substring(0, i);
            lossText2.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        lossText2.text = fullText2;

        yield return new WaitForSeconds(1f);
        restartBtn.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
