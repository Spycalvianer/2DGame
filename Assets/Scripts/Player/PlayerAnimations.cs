using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerMechanics mechanics;
    Animator anim;

    private void Awake()
    {
        mechanics = GetComponent<PlayerMechanics>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        IdleAnimation();
        RunningAnimation();
    }
    void RunningAnimation()
    {
        if( Mathf.Abs(mechanics.xAxis) > 0)
        {
            anim.SetBool("isMoving", true);
        }
    }
    void IdleAnimation()
    {
        if (Mathf.Abs(mechanics.xAxis) == 0)
        {
            anim.SetBool("isMoving", false);
        }
    }
}
