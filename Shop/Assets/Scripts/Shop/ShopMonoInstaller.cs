using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopMonoInstaller : MonoInstaller<ShopMonoInstaller>
    {
        [SerializeField] private ShopWidgetView shopWidgetViewPrefab;
        [SerializeField] private ShopWindowView shopWindowView;
        
        public override void InstallBindings()
        {
            Container.Bind<BundlesSettings>()
                .FromScriptableObjectResource("Data/BundlesSettings")
                .AsSingle();
            
            Container.Bind<ShopData>().AsTransient();
            Container.Bind<ShopManager>().AsSingle();
            
            Container.Bind<ShopWidgetView>()
                .FromComponentInNewPrefab(shopWidgetViewPrefab)
                .AsTransient();

            Container.Bind<ShopWindowView>()
                .FromComponentOn(shopWindowView.gameObject)
                .AsSingle();
        }

        private void Awake()
        {
            Container.Resolve<ShopManager>().Initialize();
        }
    }
}