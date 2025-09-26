using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public MovementComponentTypeWithSpeed MovementComponentTypeWithSpeed { get; private set; }

    [field: SerializeField] public BaseWeaponConfig StartWeaponConfig { get; private set; }
}
