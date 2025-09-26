public abstract class BaseWeapon
{
    BaseWeaponConfig _weaponConfig; // по идее в фабрика будет по типу конфига понимать что за пушка и кастить конфиг и создавать нужное оружие

    public abstract void Attack();
}
