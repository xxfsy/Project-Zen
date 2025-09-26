public class WeaponsCentricAttackComponent : BaseAttackComponent
{
    private BaseWeapon _weapon;

    public WeaponsCentricAttackComponent(BaseWeapon weapon) // дефолтное оружие сюда будет прокидываться из конфига. По идее надо будет просто забиндить в инсатллере BaseWeapon из конфига, вот только не знаю надо писать с WhenInjectedInto<T>() или нет
    {
        _weapon = weapon;
    }

    public override void Attack()
    {
        _weapon.Attack();
    }

    public void SwitchWeapon(BaseWeapon newWeapon) 
    {
        _weapon = newWeapon;
    }
}
