using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FollicleState
{
    Live,
    Obstructed,
    Active,
    Actived,
}



public class Follicle : MonoBehaviour
{
    private Image image;

    private float activedDuration;
    private float obstructedDuration;
    private float timer = 0;
    private bool isLeft;

    [SerializeField] private Hair hairPrefab;

    private FollicleState state;
    private void Awake()
    {
        
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetState(FollicleState.Live);
    }

    public void Init(float activedDuration, bool isLeft)
    {
        this.activedDuration = activedDuration;
        this.isLeft = isLeft;
    }

    public void SetObstructedDuration(float obstructedDuration)
    {
        this.obstructedDuration = obstructedDuration;
    }

    public void SetState(FollicleState state)
    {

        switch (state)
        {
            case FollicleState.Live:
                image.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f) ;

                this.state = FollicleState.Live;
                break;
            case FollicleState.Obstructed:

                image.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
                this.state = FollicleState.Obstructed;
                break;
            case FollicleState.Active:
              
                image.color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 0.5f);
                this.state = FollicleState.Active;
                break;
            case FollicleState.Actived:
                if (this.state == FollicleState.Active)
                {
                    this.state = FollicleState.Actived;
                    image.color = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.5f);
                

                    Hair oneHair = Instantiate(hairPrefab, transform);
                    int radomX = Random.Range(-20, 20);
                    int radomY = Random.Range(-5, 5);

                    oneHair.transform.localPosition = new Vector3(radomX, radomY, 0);
                    GameManager.GetInstance.SetLevelScore(GameManager.GetInstance.GetLevelScore() + 1);

                    if (this.isLeft)
                    {
                        oneHair.transform.localScale = new Vector3( 1, 1, 1);
                        LevelManager.GetInstance.leftHairList.Add(oneHair);
                    }
                    else
                    {
                        oneHair.transform.localScale = new Vector3(-1, 1, 1);
                        LevelManager.GetInstance.rightHairList.Add(oneHair);
                    }

                }
                break;
            default:
                break;
        }


    }


    public FollicleState GetState()
    {
        return state;
    }


    // Update is called once per frame
    void Update()
    {
        if (state == FollicleState.Active)
        {
            timer += Time.deltaTime;
            if (timer > activedDuration)
            {
                timer = 0;
                SetState(FollicleState.Live);
            }
        }

        if(state == FollicleState.Actived)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                SetState(FollicleState.Live);
            }
        }

        if (state == FollicleState.Obstructed)
        {
            timer += Time.deltaTime;
            if (timer > obstructedDuration)
            {
                timer = 0;
                SetState(FollicleState.Live);
            }
        }
    }
}
