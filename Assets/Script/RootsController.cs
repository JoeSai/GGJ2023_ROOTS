using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsController : MonoBehaviour
{
    [SerializeField] private float rotationalSpeed = 1.0f;
    [SerializeField] private float angle = 180f;

    [SerializeField] private float raySpeed = 10f;

    private float startAngle = 0f;
    private float currentAngle = 0f;

    [SerializeField] private Transform startPoint;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private RootsRay rootsRay;

    private float timer;
    void Start()
    {
        startAngle = transform.eulerAngles.z;

    }

    enum RootsState
    {
        Rotate,
        Busying,
    }

    private RootsState state;

    private void Awake()
    {
        state = RootsState.Rotate;
    }

    void Update()
    {

        if (state == RootsState.Busying)
        {
            return;
        }

        if (state == RootsState.Rotate)
        {
            timer += Time.deltaTime * rotationalSpeed;
            currentAngle = Mathf.Sin(timer) * angle / 2 + startAngle;
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlaySoundEffectByName("Shoot");
            state = RootsState.Busying;

            startPosition = startPoint.position;
            startPosition.z = 0;

            endPosition = startPosition + startPoint.up * 500f;
            endPosition.z = 0;

            RaycastHit2D raycastHit2D = Physics2D.Linecast(startPosition, endPosition, hitLayerMask);
            Transform hitTr = raycastHit2D.transform;


            if (hitTr)
            {
                Vector3 hitPosition = raycastHit2D.point;
                //endPosition = hitTr.position;
                endPosition = hitPosition;
                endPosition.z = 0;
            }


            rootsRay.InitializeRay(startPosition, endPosition, raySpeed, hitTr, () =>
            {
                state = RootsState.Rotate;
            });

        }


    }

    public void SetBaseValue(float rotationalSpeed, float raySpeed)
    {
        this.rotationalSpeed = rotationalSpeed;
        this.raySpeed = raySpeed;
    }
}
