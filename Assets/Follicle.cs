using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FollicleState
{
    Live,
    Dead,
    Active,
    Actived,
}

public class Follicle : MonoBehaviour
{
    private Image image;


    private FollicleState state;
    private void Awake()
    {
        
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        state = FollicleState.Live;
        image.color = Color.white;
    }

    public void SetActive()
    {
        state = FollicleState.Active;
        image.color = Color.yellow;
    }

    public void SetActived()
    {
        if (state == FollicleState.Active)
        {
            state = FollicleState.Actived;
            image.color = Color.red;
        }
    }

    public FollicleState GetState()
    {
        return state;
    }
    public void SetDead()
    {
        state = FollicleState.Dead;
        image.color = Color.black;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
