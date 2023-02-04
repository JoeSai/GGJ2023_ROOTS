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

    public void Init(float activedDuration)
    {
        this.activedDuration = activedDuration;
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
                image.color = Color.white;
                this.state = FollicleState.Live;
                break;
            case FollicleState.Obstructed:
                image.color = Color.black;
                this.state = FollicleState.Obstructed;
                break;
            case FollicleState.Active:
                image.color = Color.blue;
                this.state = FollicleState.Active;
                break;
            case FollicleState.Actived:
                if (this.state == FollicleState.Active)
                {
                    this.state = FollicleState.Actived;
                    image.color = Color.red;
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
