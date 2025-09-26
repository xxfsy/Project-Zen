using UnityEngine;

public class CharacterControllerMovementComponent : BaseMovementComponent
{
    private CharacterController _characterController;

    public CharacterControllerMovementComponent(CharacterController characterController, float speed = 1f) : base (speed) 
    {
        _characterController = characterController;

        _characterController.enabled = true;

        Debug.Log("CharacterControllerMovementComponent constructed with CharacterController");
    }

    public override void Move(Vector2 movementDirection)
    {
        Vector3 movementDirectionV3 = new Vector3(movementDirection.x, 0, movementDirection.y);

        if(movementDirectionV3.magnitude > 1f)
            movementDirectionV3.Normalize();

        _characterController.Move(movementDirectionV3 * speed * Time.deltaTime);
    }
}
