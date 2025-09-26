using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeaponConfig", menuName = basePath + "RangeWeaponConfig")]
public class RangeWeaponConfig : BaseWeaponConfig
{
    [field: SerializeField] public float Range {  get; private set; }
    [field: SerializeField] public int ProjectileCount { get; private set; } = 1;
}
