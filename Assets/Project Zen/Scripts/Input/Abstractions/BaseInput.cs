using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInput
{
    public event UnityAction<Vector2> OnAimInput;

    public event UnityAction<Vector2> OnMoveInput;
}
