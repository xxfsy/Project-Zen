using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DesktopInput : IMovementInput, ICombatInput, IDisposable
{
    public event UnityAction<Vector2> OnMoveInput;

    public event UnityAction<Vector2> OnAimInput;

    private InputSystem_Actions _gameInput;

    public DesktopInput(InputSystem_Actions gameInput)
    {
        _gameInput = gameInput;

        Subscribe();

        Debug.Log("DesktopInput constructed with InputSystem_Actions");
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _gameInput.Enable();

        _gameInput.Player.Move.performed += OnMovePerformed;
        _gameInput.Player.Move.canceled += OnMovePerformed;
    }

    private void Unsubscribe() 
    {
        _gameInput.Player.Move.performed -= OnMovePerformed;
        _gameInput.Player.Move.canceled -= OnMovePerformed;

        _gameInput.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        OnMoveInput.Invoke(obj.ReadValue<Vector2>());
    }
}
