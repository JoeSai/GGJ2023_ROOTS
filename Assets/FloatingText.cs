using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public float destroyTime = 2.0f;
    public Text mgsText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        Destroy(gameObject, destroyTime);
    }

    public void SetText(string msg)
    {
        mgsText.text = msg;
    }

    private void FixedUpdate()
    {
   
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        float timePassed = Time.time - startTime;
        float opacity = 1.0f - timePassed / destroyTime;
        mgsText.color = new Color(mgsText.color.r, mgsText.color.g, mgsText.color.b, opacity);
    }
}