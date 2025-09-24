using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private PlayerConfig _playerConfig; // сделать потом например rigidbodyMovementComponent и с помощью этого флага проверять какой компонент сейчас забиндить. Грубо говоря это сейчас вместо конфига

    public override void InstallBindings()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint);
        Container.Bind<IDisposable>().FromInstance(player);

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Container.Bind<InputSystem_Actions>().AsSingle();
            Container.BindInterfacesTo<DesktopInput>().AsSingle();
        }

        if (_playerConfig.IsCharacterControllerMovementComponent)
        {
            CharacterController _playerCharacterController = player.GetComponent<CharacterController>();

            Container.Bind<BaseMovementComponent>().To<CharacterControllerMovementComponent>().AsSingle().WithArguments(_playerCharacterController);
        }
    }
}