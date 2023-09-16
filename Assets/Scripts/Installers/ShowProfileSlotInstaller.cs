using UnityEngine;
using Zenject;

public class ShowProfileSlotInstaller : MonoInstaller
{
    [SerializeField] private ShowProfileSlot _showProfileSlot;
    public override void InstallBindings()
    {
        Container.Bind<ShowProfileSlot>().FromInstance(_showProfileSlot).AsSingle();
    }
}