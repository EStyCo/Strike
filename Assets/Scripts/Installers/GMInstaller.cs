using UnityEngine;
using Zenject;

public class GMInstaller : MonoInstaller
{
    [SerializeField] private GM gm;
    
    public override void InstallBindings()
    {
        Container.Bind<GM>().FromInstance(gm).AsSingle().NonLazy();
    }
}
