using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    [SerializeField] private InputReader m_inputReader;

    private void Start()
    {
        m_inputReader.MoveEvent += OnMove;
        m_inputReader.LookEvent += OnLook;
        m_inputReader.FireEvent += OnFire;
    }

    private void OnFire(bool state)
    {
        Debug.Log($"Fire: {state}");
    }

    private void OnMove(Vector2 direction)
    {
        Debug.Log($"Move: {direction}");
    }

    private void OnLook(Vector2 direction)
    {
        Debug.Log($"Look: {direction}");
    }
}
