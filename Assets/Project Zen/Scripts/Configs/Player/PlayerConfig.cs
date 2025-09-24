using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public bool IsCharacterControllerMovementComponent { get; private set; } = true; // // сделать потом например rigidbodyMovementComponent и с помощью этого флага проверять какой компонент сейчас забиндить. Поменять потом на Enum а не Bool
}
