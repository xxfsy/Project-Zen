using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDisposable
{
    private BaseMovementComponent _playerMovementComponent;

    private IMovementInput _movementInput;
    private ICombatInput _combatInput;


    [Inject]
    public void Construct(BaseMovementComponent playerMovementComponent, IMovementInput movementInput, ICombatInput combatInput)
    {
        _playerMovementComponent = playerMovementComponent;

        _movementInput = movementInput;
        _combatInput = combatInput; 

        Subscribe();

        Debug.Log("Player constructed with " + _playerMovementComponent + " " + movementInput + " " + combatInput);
    }

    public void Dispose()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        _movementInput.OnMoveInput += _playerMovementComponent.Move;
    }

    private void UnSubscribe() 
    {
        _movementInput.OnMoveInput -= _playerMovementComponent.Move;
    }
}
