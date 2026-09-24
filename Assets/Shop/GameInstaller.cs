using Zenject;

public class GameInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<Player>().AsSingle().NonLazy();
        Container.Bind<Inventory>().AsSingle().Lazy();
        Container.Bind<ShopCatalog>().AsSingle().NonLazy();
    }
}