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
        m_animator.SetBool("isWalk", direction.magnitude != 0);
    }
}
