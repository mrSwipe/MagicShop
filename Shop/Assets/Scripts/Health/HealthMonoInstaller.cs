using Core.Contracts;
using UnityEngine;
using Zenject;

namespace Health.Health
{
    public class HealthMonoInstaller : MonoInstaller<HealthMonoInstaller>
    {
        [SerializeField] private HealthWidgetView healthWidgetView;
        
        public override void InstallBindings()
        {
            Container.Bind<IManager>().WithId(nameof(HealthManager)).To<HealthManager>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<FixedHealthReward>().AsTransient();
            Container.BindInterfacesAndSelfTo<HealthReward>().AsTransient();
            Container.BindInterfacesAndSelfTo<PercentHealthReward>().AsTransient();
            
            Container.BindInterfacesAndSelfTo<FixedHealthSpendable>().AsTransient();
            Container.BindInterfacesAndSelfTo<HealthSpendable>().AsTransient();
            Container.BindInterfacesAndSelfTo<PercentHealthSpendable>().AsTransient();
            
            Container.Bind<HealthWidgetView>()
                .FromComponentOn(healthWidgetView.gameObject)
                .AsSingle();
        }
    }
}