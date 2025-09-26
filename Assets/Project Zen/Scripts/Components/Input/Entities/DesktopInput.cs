using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DesktopInput : IInteractionInput, IMovementInput, ICombatInput, IDisposable
{
    public Vector2 MoveInput { get; private set; }   

    public event UnityAction OnAttackPressed;

    public event UnityAction OnInteractPressed;

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

        _gameInput.Player.Attack.performed += OnAttackPerformed;

        _gameInput.Player.Interact.performed += OnInteractPerformed;
    }

    private void Unsubscribe() 
    {
        _gameInput.Player.Move.performed -= OnMovePerformed;
        _gameInput.Player.Move.canceled -= OnMovePerformed;

        _gameInput.Player.Attack.performed -= OnAttackPerformed;

        _gameInput.Player.Interact.performed += OnInteractPerformed;

        _gameInput.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        MoveInput = obj.ReadValue<Vector2>();
    }

    private void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        OnAttackPressed?.Invoke();
    }

    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        OnInteractPressed?.Invoke();
    }
}
