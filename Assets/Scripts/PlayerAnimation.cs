using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    private Animator m_animator;

    public PlayerAnimation(Animator animator)
    {
        m_animator = animator;
    }

    public void SetCallbacks(InputReader inputReader)
    {
        inputReader.MoveEvent += OnMove;
    }

    private void OnMove(Vector2 direction)
    {
        m_animator.SetInteger("isWalkForward", Mathf.RoundToInt(direction.y));
        m_animator.SetInteger("isWalkRight", Mathf.RoundToInt(direction.x));
    }
}
