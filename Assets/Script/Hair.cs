using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    Animator hairAnimator;
    bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        hairAnimator = GetComponent<Animator>();
        AudioManager.instance.PlaySoundEffectByName("Hair_Groth");

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isDown)
        //{
        //    return;
        //}
        //AnimatorStateInfo stateInfo = hairAnimator.GetCurrentAnimatorStateInfo(0);
        //if (stateInfo.normalizedTime >= 1.0f)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void LateUpdate()
    {
        if (!isDown)
        {
            return;
        }
        AnimatorStateInfo stateInfo = hairAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetHairDown()
    {
        isDown = true;
        hairAnimator.SetTrigger("down");
        AudioManager.instance.PlaySoundEffectByName("Hair_Lost");

    }
}
