using UnityEngine;
using UnityEngine.Events;

public interface IMovementInput
{
    public event UnityAction<Vector2> OnMoveInput;
}
