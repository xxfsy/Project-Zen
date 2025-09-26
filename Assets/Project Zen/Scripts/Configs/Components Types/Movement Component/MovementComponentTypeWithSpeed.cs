using UnityEngine;

[System.Serializable]
public class MovementComponentTypeWithSpeed 
{
    [field: SerializeField] public MovementComponentTypes MovementComponentType { get; private set; }

    [field: SerializeField, Min(1)]
    public float Speed { get; private set; }
}
