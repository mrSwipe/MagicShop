using Core.Contracts;
using UnityEngine;
using Zenject;

namespace Gold
{
    public class GoldMonoInstaller : MonoInstaller<GoldMonoInstaller>
    {
        [SerializeField] private GoldWidgetView goldWidgetView;
        
        public override void InstallBindings()
        {
            Container.Bind<IManager>().WithId(nameof(GoldManager)).To<GoldManager>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GoldReward>().AsTransient();
            Container.BindInterfacesAndSelfTo<FixedGoldReward>().AsTransient();
            
            Container.BindInterfacesAndSelfTo<GoldSpendable>().AsTransient();
            Container.BindInterfacesAndSelfTo<FixedGoldSpendable>().AsTransient();
            
            Container.Bind<GoldWidgetView>()
                .FromComponentOn(goldWidgetView.gameObject)
                .AsSingle();
        }
    }
}