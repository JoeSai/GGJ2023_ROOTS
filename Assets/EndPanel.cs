using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private Text endText;

    public float typingSpeed = 0.1f;
    public string fullText = "你变秃了，也变强了";

    private string currentText = "";
    [SerializeField] GameObject restartBtn;

    private void Start()
    {
        StartCoroutine(PerformEnd());
    }

    private IEnumerator PerformEnd()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            endText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        endText.text = fullText;

        yield return new WaitForSeconds(1f);
        restartBtn.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
