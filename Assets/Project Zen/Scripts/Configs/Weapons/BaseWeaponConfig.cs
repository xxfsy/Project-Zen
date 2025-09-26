using UnityEngine;

public abstract class BaseWeaponConfig : ScriptableObject
{
    [field: SerializeField] public string WeaponName { get; private set; }

    [field: SerializeField] public float Damage { get; private set; }

    [field: SerializeField] public float AttackRate { get; private set; }

    protected const string basePath = "Configs/Weapons/";
}
