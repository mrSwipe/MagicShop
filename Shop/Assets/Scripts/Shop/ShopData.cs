using System.Collections.Generic;
using Core;
using Core.Contracts;
using Gold;
using Health;
using Location;
using Zenject;

namespace Shop
{
    public class ShopData
    {
        public string BundleName { get; private set; }
        public IRewardProcessor RewardProcessor { get; private set; }
        public ISpendableProcessor SpendableProcessor  { get; private set; }

        private GoldManager goldManager;
        private HealthManager healthManager;
        private LocationManager locationManager;
        
        public ShopData(IManager goldManagerIn, IManager healthManagerIn, IManager locationManagerIn)
        {
            goldManager = goldManagerIn as GoldManager;
            healthManager = healthManagerIn as HealthManager;
            locationManager = locationManagerIn as LocationManager;
        }
        
        public void SetData(BundleData data)
        {
            BundleName = data.BundleName;
            
            switch (data.Reward)
            {
                case BaseGoldReward goldReward:
                    RewardProcessor = new RewardProcessor(goldManager, goldReward);
                    break;
                case BaseHealthReward healthReward:
                    RewardProcessor = new RewardProcessor(healthManager, healthReward);
                    break;
                case LocationReward locationReward:
                    RewardProcessor = new RewardProcessor(locationManager, locationReward);
                    break;
            }

            switch (data.Spend)
            {
                case BaseGoldSpendable goldSpendable:
                    SpendableProcessor = new SpendableProcessor(goldManager, goldSpendable);
                    break;
                case BaseHealthSpendable healthSpendable:
                    SpendableProcessor = new SpendableProcessor(healthManager, healthSpendable);
                    break;
            }
        }
    }
}