using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    private CharacterController m_characterController;

    private Vector2 m_moveDirection;
    private Vector2 m_lookDirection;

    private float m_velocityY = 0f;
    private bool m_onGround = false;
    private float m_xRotate = 0;

    public PlayerMovement(CharacterController characterController)
    {
        m_characterController = characterController;
    }

    public void SetCallbacks(InputReader inputReader)
    {
        inputReader.MoveEvent += OnMove;
        inputReader.LookEvent += OnLook;
        inputReader.FireEvent += OnFire;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ApplyGravity()
    {
        m_onGround = m_characterController.isGrounded;
        if (m_onGround && m_velocityY < 0)
        {
            m_velocityY = 0f;
        }

        m_velocityY += Physics2D.gravity.y * Time.deltaTime;
    }

    public void MovePosition(Transform transform, float speed)
    {



        if (m_moveDirection.magnitude != 0)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);

            Vector3 direction = transform.forward * m_moveDirection.y + transform.right * m_moveDirection.x;
            m_characterController.Move(direction * speed * Time.deltaTime);
        }
    }

    public void RotateLook(Transform transform)
    {
       /* if (m_moveDirection.magnitude != 0)
            transform.rotation = Quaternion.Euler(0f, m_camera.rotation.eulerAngles.y, 0f);*/
    }

    private void OnFire(bool state)
    {

    }

    private void OnMove(Vector2 direction)
    {
        m_moveDirection = direction;
    }

    private void OnLook(Vector2 direction)
    {
        m_lookDirection = direction;
    }
}
