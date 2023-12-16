using UnityEngine;
using Zenject;

public class LevelManagerInstaller : MonoInstaller
{
    [SerializeField] private LevelManager lm;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelManager>().FromInstance(lm).AsSingle().NonLazy();
    }
}
