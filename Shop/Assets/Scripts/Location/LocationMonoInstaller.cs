using Core.Contracts;
using UnityEngine;
using Zenject;

namespace Location
{
    public class LocationMonoInstaller : MonoInstaller<LocationMonoInstaller>
    {
        [SerializeField] private LocationWidgetView locationWidgetView;
        
        public override void InstallBindings()
        {
            Container.Bind<IManager>().WithId(nameof(LocationManager)).To<LocationManager>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LocationReward>().AsTransient();
            
            Container.Bind<LocationWidgetView>()
                .FromComponentOn(locationWidgetView.gameObject)
                .AsSingle();
        }
    }
}