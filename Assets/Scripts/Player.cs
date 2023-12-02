using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader m_inputReader;
    [SerializeField] private Transform m_spine;
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_sensitive = 5f;

    private PlayerAnimation m_playerAnimation;
    private PlayerMovement m_playerMovement;


    private void Start()
    {
        m_playerAnimation = new PlayerAnimation(GetComponent<Animator>());
        m_playerMovement = new PlayerMovement(GetComponent<CharacterController>());

        m_playerAnimation.SetCallbacks(m_inputReader);
        m_playerMovement.SetCallbacks(m_inputReader);

    }

    private void Update()
    {
        m_playerMovement.ApplyGravity();
        m_playerMovement.MovePosition(transform, m_moveSpeed);
        m_playerMovement.RotateLook(transform, m_spine, m_sensitive);   
    }

   
   
}
