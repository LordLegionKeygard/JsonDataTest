using UnityEngine;
using Zenject;

public class SpriteHolderInstaller : MonoInstaller
{
    [SerializeField] private SpriteHolder _spriteHolder;
    public override void InstallBindings()
    {
        Container.Bind<SpriteHolder>().FromInstance(_spriteHolder).AsSingle();
    }
}