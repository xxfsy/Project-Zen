using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;

    public PlayerController(PlayerMovementController playerMovementController)
    {
        _playerMovementController = playerMovementController;
    }
}
