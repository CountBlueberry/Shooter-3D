using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{


    
    static public Animator FireAnimator;

    void Update()
    {
        FireAnimator = GetComponent<Animator>();
    }


    public static void FireTriggered()
    {
        FireAnimator.Play("New State");
        FireAnimator.Play("ShootingFireAnimation");
    }
    public void StopAnimation()
    {
        FireAnimator.Play("New State");
    }
}
