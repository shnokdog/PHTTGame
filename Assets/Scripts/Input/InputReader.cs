using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, GameInput.IPlayerActions
{
    private GameInput m_gameInput;

    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction<Vector2> LookEvent;
    public event UnityAction<bool> FireEvent;

    private void OnEnable()
    {
        if (m_gameInput is null)
        {
            m_gameInput = new GameInput();
            m_gameInput.Player.SetCallbacks(this);

            m_gameInput.Player.Enable();
        }
    }


    public void OnFire(InputAction.CallbackContext context)
    {
        FireEvent?.Invoke(context.ReadValueAsButton());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
}
