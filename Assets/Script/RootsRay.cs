using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsRay : MonoBehaviour
{

    public LineRenderer lineRenderer;

    private float extendSpeed;

    [SerializeField] private float actDuration = 1f;
    [SerializeField] private float actTimer = 0f;

    private bool isExtending = false;
    private bool isFading = false;
    private bool isEnd = false;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private Vector3 curPosition;
    private Vector3 direction;

    private Transform hitFollicle;
    private Action hitCallback;

    public void Initialize(Vector3 startPos, Vector3 endPos, float extendSpeed, Transform hitFollicle, Action hitCallback)
    {
        this.startPosition = startPos;
        this.endPosition = endPos;
        this.extendSpeed = extendSpeed;
        this.hitCallback = hitCallback;
        this.hitFollicle = hitFollicle;

        direction = (endPosition - startPosition).normalized;

        curPosition = startPosition;

        lineRenderer.SetPosition(0, startPosition);
        isExtending = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isExtending)
        {
            lineRenderer.enabled = true;
            curPosition += direction * extendSpeed;
            lineRenderer.SetPosition(1, curPosition);
       

            if (Vector2.Distance(curPosition, endPosition) < 10f)
            {
                isExtending = false;
                isFading = true;

            }
            //if (extendTimer >= extendTime)
            //{
            //    isExtending = false;
            //    lineRenderer.enabled = false;
            //}

        }

        if (isFading)
        {
            actTimer += Time.deltaTime;
            if(actTimer > actDuration)
            {
                //GameObject.Destroy(gameObject);
     

                if (hitCallback != null)
                {
                    hitCallback();

                    ActivedFollicle();


                    lineRenderer.enabled = false;
                    isFading = false;
                }
            }
        }

    }

    private void ActivedFollicle()
    {
        if(hitFollicle && hitFollicle.GetComponent<Follicle>() != null)
        {
            hitFollicle.GetComponent<Follicle>().SetActived();
        }
    }
}
