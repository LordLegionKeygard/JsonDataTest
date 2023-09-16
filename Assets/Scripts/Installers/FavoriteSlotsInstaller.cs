using UnityEngine;
using Zenject;

public class FavoriteSlotsInstaller : MonoInstaller
{
    [SerializeField] private FavoriteSlots _favoriteSlots;
    public override void InstallBindings()
    {
        Container.Bind<FavoriteSlots>().FromInstance(_favoriteSlots).AsSingle();
    }
}