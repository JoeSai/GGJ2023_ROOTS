using System;

using UnityEngine;
using UnityEngine.UI;

public class RootsRay : MonoBehaviour
{

    //public LineRenderer lineRenderer;

    private float extendSpeed;

    [SerializeField] private float actDuration = 0.5f;
    [SerializeField] private float actTimer = 0f;

    private bool isExtending = false;
    private bool isFading = false;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private Vector3 curPosition;
    private Vector3 direction;

    private Transform hitFollicle;
    private Action hitCallback;

    public void InitializeRay(Vector3 startPos, Vector3 endPos, float extendSpeed, Transform hitFollicle, Action hitCallback)
    {
        this.startPosition = startPos;
        this.endPosition = endPos;
        this.extendSpeed = extendSpeed;
        this.hitCallback = hitCallback;
        this.hitFollicle = hitFollicle;

        direction = (endPosition - startPosition).normalized;

        curPosition = startPosition;

        //lineRenderer.SetPosition(0, startPosition);
        isExtending = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isExtending)
        {
            //lineRenderer.enabled = true;
            transform.GetComponent<Image>().enabled = true;
            transform.up = direction;
            curPosition += direction * extendSpeed;

            transform.position = curPosition;
            //lineRenderer.SetPosition(1, curPosition);
       

            if (Vector2.Distance(curPosition, endPosition) < 10f)
            {
                isExtending = false;
                isFading = true;
            }

        }

        if (isFading)
        {
            actTimer += Time.fixedDeltaTime;
            if(actTimer > actDuration)
            {
                actTimer = 0;
                if (hitCallback != null)
                {
                    hitCallback();

                    ActivedFollicle();


                    //lineRenderer.enabled = false;
                    transform.GetComponent<Image>().enabled = false;
                    isFading = false;
                }
            }
        }

    }

    private void ActivedFollicle()
    {
        if(hitFollicle && hitFollicle.GetComponent<Follicle>() != null)
        {
            hitFollicle.GetComponent<Follicle>().SetState(FollicleState.Actived);
        }
    }
}
