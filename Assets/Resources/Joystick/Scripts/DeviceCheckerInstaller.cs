using UnityEngine;
using Zenject;

public class DeviceCheckerInstaller : MonoInstaller
{
    [SerializeField] private DeviceChecker deviceChecker;
    
    public override void InstallBindings()
    {
        Container.Bind<DeviceChecker>().FromInstance(deviceChecker).AsSingle().NonLazy();
    }
}
