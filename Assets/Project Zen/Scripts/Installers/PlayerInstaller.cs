using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private PlayerConfig _playerConfig; 

    public override void InstallBindings()
    {
        PlayerController player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
        Container.Bind<IDisposable>().FromInstance(player).AsSingle();

        switch(SystemInfo.deviceType)
        {
            case DeviceType.Desktop:
                Container.Bind<InputSystem_Actions>().AsSingle();
                Container.BindInterfacesTo<DesktopInput>().AsSingle();
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        switch(_playerConfig.MovementComponentTypeWithSpeed.MovementComponentType)
        {
            case MovementComponentTypes.CharacterController:
                CharacterController _playerCharacterController = player.GetComponent<CharacterController>();
                Container.Bind<BaseMovementComponent>().To<CharacterControllerMovementComponent>().AsSingle().WithArguments(_playerCharacterController, _playerConfig.MovementComponentTypeWithSpeed.Speed);
                break;

            //case MovementComponentTypes.Rigidbody:
            //    Rigidbody _playerRigidbody = player.GetComponent<Rigidbody>();
            //    Container.Bind<BaseMovementComponent>().To<RigidBodyMovementComponent>().AsSingle().WithArguments(_playerRigidbody);
            //    break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        Container.Bind<WeaponsCentricAttackComponent>().AsSingle().WithArguments(new MeleeWeapon()); // new MeleeWeapon() временная заглушка, потом создать фабрику и по конфигу получать стартовое оружие из фабрики

        Container.Inject(player); // Inject-им вручную так как сначала надо забиндить все зависимости
    }
}