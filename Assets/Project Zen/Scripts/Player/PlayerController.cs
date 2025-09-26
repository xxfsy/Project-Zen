using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IDisposable
{
    private WeaponsCentricAttackComponent _playerAttackComponent; // Зависим от конкретной реализации так как вариативности нет, у игрока только такой AttackComponent может быть

    private BaseMovementComponent _playerMovementComponent;

    private IMovementInput _movementInput; // оставить разделенными или объединить? думаю оставить просто чтобы все в одной абастракции не было напихано и было видно что к чему относиться, хотя в итоге все равно весь инпут в одном классе, поэтому не знаю
    private ICombatInput _combatInput;
    private IInteractionInput _interactionInput;


    [Inject]
    public void Construct(WeaponsCentricAttackComponent playerWeaponsCentricAttackComponent, BaseMovementComponent playerMovementComponent, IMovementInput movementInput, ICombatInput combatInput, IInteractionInput interactionInput)
    {
        _playerAttackComponent = playerWeaponsCentricAttackComponent;

        _playerMovementComponent = playerMovementComponent;

        _movementInput = movementInput;
        _combatInput = combatInput; 
        _interactionInput = interactionInput;

        Subscribe();

        Debug.Log("Player constructed with " + _playerMovementComponent + " " + _movementInput + " " + _combatInput + " " + _interactionInput);
    }

    public void Dispose()
    {
        UnSubscribe();
    }

    private void Update()
    {
        _playerMovementComponent.Move(_movementInput.MoveInput);
    }

    private void Subscribe()
    {
        _combatInput.OnAttackPressed += _playerAttackComponent.Attack;

        //_interactionInput.OnInteractPressed += _playerAttackComponent.SwitchWeapon; // где сделать проверку на то можно менять оружие или нет. TryToSwitchWeapon. Думаю в отдельной сущности которая будет отвечать за любое взаимодействие
    }

    private void UnSubscribe() 
    {
        _combatInput.OnAttackPressed -= _playerAttackComponent.Attack;

        //_interactionInput.OnInteractPressed += _playerAttackComponent.SwitchWeapon;
    }
}
