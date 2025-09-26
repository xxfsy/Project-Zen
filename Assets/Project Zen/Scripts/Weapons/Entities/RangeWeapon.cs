using UnityEngine;

public class RangeWeapon : BaseWeapon // Использовать пул объектов для снарядов.
{
    private GameObject _projectilePrefab;

    public RangeWeapon(GameObject projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
    }

    public override void Attack()
    {
        Debug.Log("Range Weaopon Attack");
    }
}
