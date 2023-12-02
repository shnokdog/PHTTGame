using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    private CharacterController m_characterController;
    private Transform m_camera;

    private Vector2 m_moveDirection;
    private Vector2 m_lookDirection;

    private float m_velocityY = 0f;
    private bool m_onGround = false;
    private float m_xRotate = 0;

    public PlayerMovement(CharacterController characterController)
    {
        m_characterController = characterController;
        m_camera = Camera.main.transform;
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

        Vector3 direction = transform.up * m_velocityY;

        if (m_moveDirection.magnitude != 0)
            direction += transform.forward * m_moveDirection.y + transform.right * m_moveDirection.x;   
        
        m_characterController.Move(direction * speed * Time.deltaTime);
    }

    public void RotateLook(Transform transform, Transform spine ,float sensitive)
    {
        float x = m_lookDirection.x * sensitive * Time.deltaTime;
        float y = m_lookDirection.y * sensitive * Time.deltaTime;

        m_xRotate -= y;
        m_xRotate = Mathf.Clamp(m_xRotate, -90f, 90f);

        spine.localRotation = Quaternion.Euler(m_xRotate, 0, 0);
        transform.Rotate(Vector3.up * x);
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
