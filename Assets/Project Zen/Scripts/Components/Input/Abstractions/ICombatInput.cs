using UnityEngine;
using UnityEngine.Events;

public interface ICombatInput 
{
    public event UnityAction<Vector2> OnAimInput;
}
