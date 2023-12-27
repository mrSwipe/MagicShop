using System.Collections.Generic;
using Core.Contracts;
using Gold;
using Health;
using Location;
using Zenject;

namespace Shop
{
    public class ShopManager : IInitializable
    {
        [Inject] private BundlesSettings bundlesSettings;
        
        private GoldManager goldManager;
        private HealthManager healthManager;
        private LocationManager locationManager;

        public IList<ShopData> ShopData { get; } = new List<ShopData>();
        
        [Inject]
        private void Construct(BundlesSettings bundlesSettingsIn, 
            [Inject(Id = nameof(GoldManager))] IManager goldManagerIn, 
            [Inject(Id = nameof(HealthManager))] IManager healthManagerIn, 
            [Inject(Id = nameof(LocationManager))] IManager locationManagerIn)
        {
            bundlesSettings = bundlesSettingsIn;
            goldManager = goldManagerIn as GoldManager;
            healthManager = healthManagerIn as HealthManager;
            locationManager = locationManagerIn as LocationManager;
        }

        public void Initialize()
        {
            foreach (var bundle in bundlesSettings.Bundles)
            {
                var shopData = new ShopData(goldManager, healthManager, locationManager);
                shopData.SetData(bundle);
                
                ShopData.Add(shopData);
            }
        }
    }
}