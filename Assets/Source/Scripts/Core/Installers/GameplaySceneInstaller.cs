using System;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Player _player;
    [SerializeField] private Finish _finish;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void InstallBindings()
    {
        BindFinish();
        BindMovenent();
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
        Player player = Container.InstantiatePrefabForComponent<Player>(_player, _playerSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindMovenent()
    {
        Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle().NonLazy();
        Container.BindInterfacesTo<DesktopInput>().FromNew().AsSingle();
    }

    private void BindFinish()
    {
        Container.Bind<Finish>().FromInstance(_finish).AsSingle();
    }
}
