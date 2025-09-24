using UnityEngine;

public class CharacterControllerMovementComponent : BaseMovementComponent
{
    private CharacterController _characterController;

    public CharacterControllerMovementComponent(CharacterController characterController)
    {
        _characterController = characterController;

        _characterController.enabled = true;

        Debug.Log("CharacterControllerMovementComponent constructed with CharacterController");
    }

    public override void Move(Vector2 movementDirection)
    {
        _characterController.Move(new Vector3(movementDirection.x, 0, movementDirection.y));
    }
}
