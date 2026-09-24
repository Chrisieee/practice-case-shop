using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller {
    [SerializeField] private TextAsset catalogJson;
    [SerializeField] private ShopUi shopUi;
    [SerializeField] private EquipmentUi equipmentUi;

    public override void InstallBindings() {
        Container.Bind<Player>().AsSingle().NonLazy();
        Container.Bind<Inventory>().AsSingle().Lazy();
        Container.Bind<ShopManager>().AsSingle().NonLazy();
        Container.Bind<ShopCatalog>().AsSingle().NonLazy();
        Container.Bind<EquipmentManager>().AsSingle().NonLazy();

        Container.Bind<TextAsset>().FromInstance(catalogJson).AsSingle();

        Container.Bind<ShopUi>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EquipmentUi>().FromComponentInHierarchy().AsSingle();
    }
}